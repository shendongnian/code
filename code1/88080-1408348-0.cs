    IList<Parent> parents = ... //Populated
    parents = (from p in parents
               orderby p.Name
               select new Parent
               {
                   Name = p.Name,
                   Children = p.Children.OrderBy(c => c.Name).ToList()
               }
              ).ToList();
         
