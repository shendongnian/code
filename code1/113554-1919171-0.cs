    List<User> Users = new List<User>();
    Users.Add(new User() { FirstName = "John", LastName = "Smith" });
    Users.Add(new User() { FirstName = "Jane", LastName = "Smith" });
    
    
    string Query = "John";
    
    var Queryable = Users.AsQueryable();
    
    var Results = (from u in Queryable
    			   select u);
    
    //initial method call... the lambda u => false is a place-holder that is about to be replaced
    MethodCallExpression WhereExpression = (MethodCallExpression)Results.Where(u => false).Expression;
    
    //define search options
    Expression<Func<User, string, bool>> FilterLastName = (u, query) => u.LastName.Contains(query);
    Expression<Func<User, string, bool>> FilterFirstName = (u, query) => u.FirstName.Contains(query);
    
    //build a lambda based on selected search options... tie the u parameter to UserParameter and the query parameter to our Query constant
    ParameterExpression UserParameter = Expression.Parameter(typeof(User), "u");
    Expression Predicate = Expression.Constant(false);	//for simplicity, since we're or-ing, we'll start off with false || ...
    
    //if (condition for filtering by last name)
    {
    	Predicate = Expression.Or(Predicate, Expression.Invoke(FilterLastName, UserParameter, Expression.Constant(Query)));
    }
    
    //if (condition for filtering by first name)
    {
    	Predicate = Expression.Or(Predicate, Expression.Invoke(FilterFirstName, UserParameter, Expression.Constant(Query)));
    }
    
    //final method call... lambda u => false is the second parameter, and is replaced with a new lambda based on the predicate we just constructed
    WhereExpression = Expression.Call(WhereExpression.Object, WhereExpression.Method, WhereExpression.Arguments[0], Expression.Lambda(Predicate, UserParameter));
    
    //get a new IQueryable for our new expression
    Results = Results.Provider.CreateQuery<User>(WhereExpression);
    
    //enumerate results as usual
    foreach (User u in Results)
    {
    	Console.WriteLine("{0} {1}", u.FirstName, u.LastName);
    }
