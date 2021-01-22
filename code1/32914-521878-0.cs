    public void GetEmployees(objEmployee)
    {
      //the function I am calling returns a dataTable of all the employees in the db.
      dim dt as DataTable = dbEmployees.GetEmployees(); 
    
       foreach(DataRow drow in dt.rows) 
         {
            objEmployee.Name = drow["Name"].ToString();
            objEmployee.ID = drow["ID"].ToString();
         }
    }
