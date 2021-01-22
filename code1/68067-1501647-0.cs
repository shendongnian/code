    // Remove the error from ModelState which will have the same name as the collection.
    ModelState.Remove("Complaints"/*EntityCollection*/); 
    if (ModelState.IsValid) // Still catches other errors.
    {
        entities.SaveChanges(); // Your ObjectContext
    }
