    using (var context = new BloggingContext()) 
    { 
      using (var dbContextTransaction = context.Database.BeginTransaction()) 
      { 
        try 
        { 
          context.Database.ExecuteSqlCommand( 
              @"UPDATE Blogs SET Rating = 5" + 
                  " WHERE Name LIKE '%Entity Framework%'" 
              ); 
    
          var query = context.Posts.Where(p => p.Blog.Rating >= 5); 
          foreach (var post in query) 
          { 
              post.Title += "[Cool Blog]"; 
          } 
    
          context.SaveChanges(false); 
    
          dbContextTransaction.Commit(); 
          
          context.AcceptAllChanges();
        } 
        catch (Exception) 
        { 
          dbContextTransaction.Rollback(); 
        } 
      } 
    } 
