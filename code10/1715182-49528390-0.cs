    using (var db = new DataStore())
    {
    	var students = db.Students.DoSomeLinq(...);
    	var teachers = db.Teachers.SomeLinq(...);
    	
    	// do some work ...
    	// note: The entities in students and teachers are still bound to the DbContext internal to DataStore!
    	
    	// optional 
    	db.SaveChanges();
    }
