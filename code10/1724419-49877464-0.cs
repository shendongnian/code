    public void Generate() {
        DbContext context = GetDbContext();
        DoSomething(context);
        DoSomethingElse(context);
    }
    
    public void DoSomething(DbContext context) {
        var something = new Something();
    
        // add new object and save only this new object
    
        context.SaveChanges();
    }
    
    public void DoSomethingElse(DbContext context) {
        context.Add(new MyUser());
        context.Add(new MyUser());    
        context.SaveChanges();
    }
