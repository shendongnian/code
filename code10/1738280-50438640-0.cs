    using Z.EntityFramework.Plus;
...
    public MyContext() : base("MyContext")
    {
        this.Filter<EntityBase>(q => q.Where(x => x.Status != "Deleted"));
    }
