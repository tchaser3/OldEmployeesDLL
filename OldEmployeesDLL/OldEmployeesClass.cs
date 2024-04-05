/* Title:           Old Employees Dll
 * Date:            4-25-17
 * Author:          Terry Holmes
 * 
 * Description:     This class is for importing the old employees */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace OldEmployeesDLL
{
    public class OldEmployeesClass
    {
        //setting up the classes
        EventLogClass TheEventLogClass = new EventLogClass();

        //setting up the data
        OldEmployeesDataSet aOldEmployeesDataSet;
        OldEmployeesDataSetTableAdapters.employeesTableAdapter aOldEmployeesTableAdapter;

        public OldEmployeesDataSet GetOldEmployeesInfo()
        {
            try
            {
                aOldEmployeesDataSet = new OldEmployeesDataSet();
                aOldEmployeesTableAdapter = new OldEmployeesDataSetTableAdapters.employeesTableAdapter();
                aOldEmployeesTableAdapter.Fill(aOldEmployeesDataSet.employees);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Old Employee Class // Get Old Employee Info " + Ex.Message);
            }

            return aOldEmployeesDataSet;
        }
        public void UpdateOldEmployeesDB(OldEmployeesDataSet aOldEmployeesDataSet)
        {
            try
            {
                aOldEmployeesTableAdapter = new OldEmployeesDataSetTableAdapters.employeesTableAdapter();
                aOldEmployeesTableAdapter.Update(aOldEmployeesDataSet.employees);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Old Employee Class // Update Old Employee DB " + Ex.Message);
            }
        }
    }
}
