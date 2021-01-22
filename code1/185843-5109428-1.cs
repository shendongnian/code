    // Project is is object/table, no POCO here.
    
    var newProj = new Project();
    newProj.Name = "Blah project";
    
    var db = new AppDataContextname();
    
    db.Projects.AddObject(newProj);
     
    // at this point, newProj.ID is NOT set
    
    db.SaveChanges(); // record is added to db.
    // now, the ID property of the Project object is set!!!
    // if the last ID in that table is '25', and you have auto-increment,
    // then the object's ID property will now be 26!
    Response.Write(newProj.ID); // will output "26"
