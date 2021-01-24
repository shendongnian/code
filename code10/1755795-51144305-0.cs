    using (var context = new TestDbContext())
    {
      var child = new Child { Name = "test", ParentId = 10 }; 
      context.Children.Add(child); 
      context.SaveChanges();
      Assert.IsNull(child.Parent);
    }
