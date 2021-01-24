    using (var context = new OCWRContext())
    {
        string statusCode = "A";
        Status status =
            context.Statuses.Find(statusCode) //Step 1
            ?? context.Statuses.Add(new Status { Code = statusCode, Description = "" }).Entity; //Step 2
        var someThing = new SomeThing
        {
            Status = status, //Step 3
            Description = ""
        };
        context.Add(someThing);
        context.SaveChanges();
    }
