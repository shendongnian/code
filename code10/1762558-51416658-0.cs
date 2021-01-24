    var foo = DbContext
                .Set<Task>()
                .Select(x => new{x.Assignee, x.Availability})
                .ToList();
            
            var foo2 = DbContext
                .Set<Task2>()
                .Select(x => x)
                .ToList();
            var bar = foo2.Where(x => foo.Select(y => y.Assignee).Contains(x.Assignee) 
                                      && foo.Select(y => y.Availability).Contains(x.Availability));
            
            DbContext.RemoveRange(bar);
            DbContext.SaveChanges();
