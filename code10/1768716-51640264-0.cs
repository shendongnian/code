    // GET: People
    public ActionResult Index()
    {
        var propertyName = "Description";
        var compareString = "abc";
        var parameter = Expression.Parameter(typeof(Person));
        var memberAccess = Expression.MakeMemberAccess(parameter, typeof(Person).GetProperty(propertyName));
        var compare = Expression.Constant(compareString);
        var contains = Expression.Call(memberAccess, typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) }), compare);
        var expr = Expression.Lambda<Func<Person, bool>>(contains, new[] { parameter });
        return View(db.People.Where(expr).ToList());
    }
