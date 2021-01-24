        public void PrintEmployeeHierarchy(List<Employee> nestedEmployees, ref string result)
        {
            foreach (Employee employee in nestedEmployees)
            {
                if (employee.Subordinates != null && employee.Subordinates.Count > 0)
                {
                    PrintEmployeeHierarchy(employee.Subordinates, ref result);
                }
                result += string.Format("{0} {1} {2}", employee.FirstName, employee.LastName, "\t");
            }
        }
     
