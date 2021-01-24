    var dbConnection = "DefaultConnection2";
    using (var ctx = new FacilityEntities(dbConnection))
    {
       // any EF queries using ctx go here
    }
