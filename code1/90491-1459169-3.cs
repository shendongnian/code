    // The 'Person' object has been detached
    // from the originating 'DataContext', which is now disposed
    person.PersonCategories.Add(new PersonCategory() { CategoryName = "Employee" });
    person.PersonCategories(0).CategoryName = "Consultant";
    
    using (var db = new DataContext())
    {
        // Will detect added and deleted objects
        // in the 'PersonCategory' collection        
        db.Person.Attach(person);
        
        // Required to detect and modifications
        // to existing objects in the 'PersonCategory' collection
        foreach (var personCategory in person.PersonCategories)
        {
            db.PersonCategory.Attach(personCategory);
        }
    
        db.SubmitChanges();
    }
