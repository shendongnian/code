    using (var db = new DefaultTestEntities())
    {
        db.DateDefaultTests.Add(new DateDefaultTest
        {
             SomeField = "Bananas"
        });
        db.DateDefaultTests.Add(new DateDefaultTest
        {
             SomeField = "Apples",
        });
    
        db.SaveChanges();
    }
