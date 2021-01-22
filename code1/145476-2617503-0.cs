    List<Employee> employees = new List<Employee>();
    using (IDataReader csv = new CsvReader
                 (new StreamReader("D:\\sample.txt"), true, '|'))
    {
        while(csv.Read()) {
            Employee emp = new Employee();
            emp.ID = r.GetString(0); // or int.Parse(...) if it is an int
            emp.Name = r.GetString(1);
            emp.Dob = r.GetString(2); // or DateTime.Parse(...) if it is a DateTime
            employees.Add(emp);
        }
    }
