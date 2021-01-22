    public static Employee getEmployee(int EmployeeId)
        {
            HttpContext context = HttpContext.Current;
            string key = e.ToString() + "_" + EmployeeId;
            Employee e = (Employee)context.Session[key];
            if (e == null)
            {
                e = new Employee(EmployeeId);
                context.Session[key] = e;
            }
            return e;
        }
