        using { ...
                // connecction open here.
        
                ...
                context.Blogs.Add(blog); 
                context.SaveChanges();   // query etc now opens and immediately closes 
                    
                ...
                context.Blogs.Add(blog); 
                context.SaveChanges();   // query etc now opens and immediately closes 
       }
