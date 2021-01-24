    . . .
    using (var ctx = new BloggingContext()) 
    {
        var members = ctx.Members.Where(x => x.LastName = "Jones");
    }
    return members;
    . . . 
