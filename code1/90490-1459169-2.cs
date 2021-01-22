    using (var db = new DataContext())
    {
        var person = db.Persons.Where(p => p.Name == "Foo").SingleOrDefault();
    
        if (person != null)
        {
            // Inserts a new row in the 'PersonCategory' table
            // associated to the current 'Person'
            // and to the 'Category' with name 'Employee'
            person.PersonCategories.Add(new PersonCategory() { CategoryName = "Employee" });
    
            // Updates the 'CategoryName' column in the first row
            // of the 'PersonCategory' table associated to the current 'Person'
            person.PersonCategories(0).CategoryName = "Consultant";
    
            db.SubmitChanges();
        }
    }
