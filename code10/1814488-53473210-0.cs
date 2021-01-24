    public bool RemoveEmployee(int[] employeeIds)
            {
                foreach (int employeeId in employeeIds)
                {
                    Employee removeEmployee = context.Employees.Single(c => c.EmployeeID == employeeId); 
                    if (removeEmployee !=null && removeEmployee.WorkStatus == "Available")
                    {
                        context.Employees.Remove(removeEmployee);
                        context.SaveChanges();
                        return true;
                    }        
                }
                return false;
            }
