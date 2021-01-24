    void UpdateActiveInDatabase(MyDbContext myDb){
        var models = myDb.myModels.Where(model => !model.IsActive && model.StartDate <= DateTime.UtcNow); //These models should be active
        foreach(var model in models) { model.IsActive = true; }
        myDb.SaveChanges();
    }
