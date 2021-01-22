    using (var context = new UnicornsContext())
    
        var princess = context.Princesses.Find(1);
        // Count how many unicorns the princess owns 
        var unicornHaul = context.Entry(princess)
                          .Collection(p => p.Unicorns)
                          .Query()
                          .Count();
    }
