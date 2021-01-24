    //I guess you can take this values from controls on your form
    string database = "Person1";
    int id = 1;
    string name = "Charlie";
    //get type of an entity
    Type entityType = this.GetType().Assembly.GetTypes().Where(t => t.Name == database).First();
    //geet object of an entity class
    var entity = Convert.ChangeType(Activator.CreateInstance(entityType), entityType);
    //set properties (name and id)
    entity.GetType().GetProperty("Id").SetValue(entity, id);
    entity.GetType().GetProperty("Name").SetValue(entity, name);
    MyContext ctx = null;
    try
    {
        ctx = (MyContext)Activator.CreateInstance(typeof(MyContext));
        //here we'll loop thorugh properties of context (through databases),
        //if name match, add entity using reflection
        foreach (PropertyInfo property in ctx.GetType().GetProperties())
        {
            if (property.Name == database)
            {
                var dbSet = property.GetValue(ctx);
                //get Add method and invoke it with entity object
                dbSet.GetType().GetMethod("Add").Invoke(dbSet, new object[]{ entity });
                ctx.SaveChanges();
            }
        }
    }
    finally
    {
        //always remeber to call Dispose method!
        if(ctx != null)
            ctx.Dispose();
    }
