    using (var db = new ModelDbContext())
    {
        var parameters = new SqlParameter[]
        {
    	    new SqlParameter("@Id", SqlDbType.Int),
        };
        parameters[0].Value = 1234;
    
        var items = db.FunctionTableValue<Foo>("fn_GetFoos", parameters);
    }
