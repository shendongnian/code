    using (var context = new MyContext())
    {
      context.MyEntities.AddObject(myNewObject);
      context.SaveChanges();
      int id = myNewObject.Id;
    }
