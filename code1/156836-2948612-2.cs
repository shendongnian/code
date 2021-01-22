    // fetch an employee which will not be changed in the application
    Employee original;
    using(var db = new TestDbDataContext())
    {
      original = db.Employees.First(e => e.ID == 2);
    }
    
    // create an instance to work with
    var modified = new Employee {ID = original.ID, Name = original.Name, Notes = original.Notes};
    
    // change some info
    modified.Notes = string.Format("new notes as of {0}", DateTime.Now.ToShortTimeString());
    
    // update
    using(var db = new TestDbDataContext())
    {
      db.Employees.Attach(original);
      original.Notes = modified.Notes;
      db.SubmitChanges();
    }
