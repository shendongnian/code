    // these would come from the ui
    int? gender = 1;
    var complexion = new[]
                         {
                            "FAIR",
                            "BLACK"
                         };
    var qualification = "BACHELOR";
    
    // setup
    var connection = new SqlConnection("...");
    var compiler = new SqlServerCompiler();
    var db = new QueryFactory(connection, compiler);
    //query
    var query = db.Query("TBL_PROFILE");
    
    if (gender != null)
       query = query.Where("GENDER", gender);
    
    if (complexion != null)
       query = query.WhereIn("COMPLEXION ", complexion);
    
    if (qualification != null)
       query = query.Where("QUALIFICATION ", qualification);
    
    ...
    var results = query.Get();
    
    foreach (var profile in results)
    {
       Console.WriteLine($"{profile.Id}: {profile.Name}");
    }
