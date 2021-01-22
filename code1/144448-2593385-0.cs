    //EmpList is a List`<Employee>`
    public void DeleteEmployee(int employeeNumber)
    {
    //Assumes you will never have multiple entries with the same EE#, or that
    //if you do you want to delete all records
       for(int i = EmpList.Count -1; i>= 0; i--)
       {
           if(EmpList[i].EmployeeNumber == employeeNumber)
           EmpList.Remove(EmpList[i]);
       }
       //Call code to reserialize (to file, db, whatever)
    }
