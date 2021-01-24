    students entity = new students() {
        Id = 1,
        City = "New York",
        Name = "Sam"
    };
    using(SomeContext ctx = new SomeContext())
    {
        ctx.Entry(entity).State = EntityState.Modified;
        ctx.SaveChanges();
    }
