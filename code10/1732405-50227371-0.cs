    using (UniContext db = new UniContext())
    {
        Database.SetInitializer<UniContext>(null); // Prevents initialization exceptions
        var emp = db.Employees.First();
        Debug.WriteLine($"Hello { emp.FirstName } { emp.LastName }!");
    }
