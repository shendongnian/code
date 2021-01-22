    Person newPerson = new Person();
    newPerson.Id = 1;
    // substitute the correct strings for your mapping.
    newPerson.CategoryReference.EntityKey = 
        new EntityKey("MyEntities.Categories", "CategoryId", 1);
    context.AddToPersonSet(newPerson);
    context.SaveChanges();
