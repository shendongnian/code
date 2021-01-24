    var myDictionary = new Dictionary<string, Func<DbContext, IQueryable>>()
    {
        { "TblStudents", ( DbContext context ) => context.Set<TblStudent>() }
    };
    var dbSet = myDictionary[ "TblStudents" ].Invoke( dbContext );
