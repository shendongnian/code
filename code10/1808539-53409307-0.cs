            public string Error
            {
                get { return error; }
            }
            public string this[string columnName]
            {
                get
                {
                    int output;
                    List <string> validateErrorList = new List<string>();
                    error = string.Empty;
    
                    if (columnName == "DynamicSearchEmployeeName")
                    {
    
                        if (string.IsNullOrWhiteSpace(DynamicSearchEmployeeName))
                        {
                            validateErrorList.Add("Employee Name is required to add a new Employee !");
                        }
                        if ((!Regex.IsMatch(DynamicSearchEmployeeName, @"^[a-zA-Z]+$")))
                        {
                            validateErrorList.Add("Employee Name has to contain only a-z, A-Z letters!");
                        }
    
                    }
                    if (columnName == "DynamicSearchEmployeeSalary" && SelectedEmployee == null)
                    {
                        if (string.IsNullOrWhiteSpace(DynamicSearchEmployeeSalary))
                        {
                            validateErrorList.Add("Employee Salary is required to add a new Employee !");
                        }
                        if (!Int32.TryParse(dynamicSearchEmployeeSalary, out output))
                        {
                            validateErrorList.Add("Employee Salary has to be number !");
                            validateErrorList.Add("Employee Salary cannot be less than 5 !");
                            validateErrorList.Add("Employee Salary cannot be less than 10 !");
                            validateErrorList.Add("Employee Salary cannot be less than 100 !");
                        }
                        if (Int32.TryParse(dynamicSearchEmployeeSalary, out output))
                        {
                            if (string.IsNullOrWhiteSpace(DynamicSearchEmployeeSalary) || EmployeeSalary < 5)
                            {
                                validateErrorList.Add("Employee Salary cannot be less than 5 !");
                            }
                            if (string.IsNullOrWhiteSpace(DynamicSearchEmployeeSalary) || EmployeeSalary < 10)
                            {
                                validateErrorList.Add("Employee Salary cannot be less than 10 !");
                            }
                            if (string.IsNullOrWhiteSpace(DynamicSearchEmployeeSalary) || EmployeeSalary < 100)
                            {
                                validateErrorList.Add("Employee Salary cannot be less than 100 !");
                            }
                        }
                    }
                    if (columnName == "DynamicSearchEmployeeSalary" && SelectedEmployee != null)
                    {
                        if (string.IsNullOrWhiteSpace(DynamicSearchEmployeeSalary))
                        {
                            validateErrorList.Add("Employee Salary is required to add a new Employee !");
                        }
                        if (!Int32.TryParse(DynamicSearchEmployeeSalary, out output))
                        {
                            validateErrorList.Add("Employee Salary has to be number !");
                            validateErrorList.Add("Employee Salary cannot be less than 5 !");
                            validateErrorList.Add("Employee Salary cannot be less than 10 !");
                            validateErrorList.Add("Employee Salary cannot be less than 100 !");
                        }
                        if (Int32.TryParse(DynamicSearchEmployeeSalary, out output))
                        {
                            if (string.IsNullOrWhiteSpace(DynamicSearchEmployeeSalary) || Convert.ToInt32(DynamicSearchEmployeeSalary) < 5)
                            {
                                validateErrorList.Add("Employee Salary cannot be less than 5 !");
                            }
                            if (string.IsNullOrWhiteSpace(DynamicSearchEmployeeSalary) || Convert.ToInt32(DynamicSearchEmployeeSalary) < 10)
                            {
                                validateErrorList.Add("Employee Salary cannot be less than 10 !");
                            }
                            if (string.IsNullOrWhiteSpace(DynamicSearchEmployeeSalary) || Convert.ToInt32(DynamicSearchEmployeeSalary) < 100)
                            {
                                validateErrorList.Add("Employee Salary cannot be less than 100 !");
                            }
                        }
                    }
                    if (columnName == "DynamicSearchEmployeeDesigner" && string.IsNullOrWhiteSpace(DynamicSearchEmployeeDesigner))
                    {
                        validateErrorList.Add("Employee Designer is required to add a new Employee !");
                    }
    
                    foreach (var validateerroritem in validateErrorList)
                    {
                        error += validateerroritem+"\r\n";
                    }
                    error = error.ToString().TrimEnd('\r', '\n');
    
                    if(error == string.Empty)
                    {
                        IsValidated = true;
                    }
                    else if (error != string.Empty)
                    {
                        IsValidated = false;
                    }
                    return error;
                }
            }
