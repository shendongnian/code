    var ListofUtilizator= dt.AsEnumerable().Select(r =>
        new utilizator
        {
            user_id= r.Field<int>("user_id"),
            user_name= r.Field<string>("user_name")
        }).ToList();
 
