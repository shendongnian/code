    var rule = RuleEngine.CreateRule<Employee>()
                         .If<Employee>(e => e.EmployeeSalary).GreaterThan(DynamicSearchEmployeeSalary)
                         .Validate();
    FilteredCollection.Filter = x => (
                        (string.IsNullOrEmpty(DynamicSearchEmployeeName) || ((Employee)x).EmployeeName.Contains(DynamicSearchEmployeeName))
                        && (DynamicSearchEmployeeID == null || ((Employee)x).EmployeeID == DynamicSearchEmployeeID)
                        && (string.IsNullOrEmpty(DynamicSearchEmployeeSalary) || rule.Match((Employee)x).IsMatch)
                        && (string.IsNullOrEmpty(DynamicSearchEmployeeDesigner) || ((Employee)x).EmployeeName.Contains(DynamicSearchEmployeeDesigner))
                        && (string.IsNullOrEmpty(DynamicSearchEmployeeEmailID) || ((Employee)x).EmployeeName.Contains(DynamicSearchEmployeeEmailID))
