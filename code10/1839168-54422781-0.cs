    MySaveEventHandler _mySaveEventHandler;
    
    public MyDbContext(DbContextOptions<MyDbContext> options, MySaveEventHandler mySaveEventHandler) : base(options) {
        _mySaveEventHandler = mySaveEventHandler;
    }
    public override int SaveChanges() {
        if(_mySaveEventHandler.OnSave != null)
             _mySaveEventHandler.OnSave(ChangeTracker.Entries());
    
        return base.SaveChanges();
    }
