    private void OnButton_Click(object sender, EventArgs e)
    {
    	EmployeeDataGridView.Rows.Clear();
    
    	//Read from JSON file
    	string JSONstring = File.ReadAllText("JSON.json");
    	List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(JSONstring);
    
        object filter = ((Control)sender).Tag;
        List<Employee> FTEmp;
        if (filter != null) {
    	    //LINQ Query for FT Employees
    	    FTEmp = from emp in employees
    				    where emp.GetTaxForm == filter.ToString()
    				   select emp;
        }
        else 
        {
           FTEmp = employees.ToList();
        }
    
    	//Display into DataGridView
    	foreach (Employee emp in FTEmp)
    	{
    		string[] row = { emp.Name, emp.Zip, emp.Age.ToString(), string.Format("{0:C}", emp.Pay),
    			emp.DepartmentId.ToString(), SetDevType(emp.DepartmentId),
    			string.Format("{0:C}", emp.CalculateTax(emp.Pay)),
    			string.Format("{0:C}", AnnualPay(emp.Pay) - emp.CalculateTax(emp.Pay))};
    		EmployeeDataGridView.Rows.Add(row);
    	}
    }
