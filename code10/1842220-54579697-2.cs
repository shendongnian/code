     protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (EmployeeID.PrintAllEmployees == "ALL EMPLOYEES")
                {
                    PrintAllEmployeesMethod();
                }
                else if (EmployeeID.PrintAllEmployees == "HIRED EMPLOYEES")
                {
                    PrintHiredEmployeesMethod();
                }
                else if (EmployeeID.PrintAllEmployees == "REJECTED EMPLOYEES")
                {
                    PrintRejectedEmployeesMethod();
                }
                else if (EmployeeID.PrintAllEmployees == "UNVERIFIED EMPLOYEES")
                {
                    PrintUnverifiedEmployeesMethod();
                }
                else
                {
                    //SOMETHING
                }
            }
        }
