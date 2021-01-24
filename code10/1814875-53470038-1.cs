    var dbContext01 = new DbContext01();
    var dbContext02 = new DbContext02();
    
    var repository01 = new Repository<DbContext01>(dbContext01);
    var repository02 = new Repository<DbContext02>(dbContext02);
    
    repository01.Create(new EntityOnDbContext01 {
        Property01A = "String",
        Property01B = "String"
    });
    
    repository02.Create(new EntityOnDbContext02 {
        Property02A = 12345,
        Property02B = 12345
    });
