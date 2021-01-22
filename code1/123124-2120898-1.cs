    private List<Employee> _Employees;
    protected void btnUp_Click(object sender, EventArgs e)
    {
        Button btnUp = sender as Button;
        int employeeID = int.Parse(btnUp.CommandArgument); // get the bound PK
        Employee toMoveUp = _Employees.Where(e=>e.EmployeeID == employeeID).FirstOrDefault();
        // assuming PlaceInLine is unique among all employees...
        Employee toMoveDown = _Employees.Where(e=>e.PlaceInLine == toMoveUp.PlaceInLine + 1).FirstOrDefault();
        
        // at this point you need to ++ the employees sequence and
        // -- the employee ahead of him  (e.g. move 5 to 6 and 6 to 5)
        
        toMoveUp.PlaceInLine ++;
        toMoveDown.PlaceInLine --;
    
        // save the list 
        DataAccessLayer.Save(_Employees);
        //rebind the listivew
        myListView.DataBind();
    
    }
