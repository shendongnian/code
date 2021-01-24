     options.Events.OnTokenValidated = async (context) =>
       {
       
           
           var dbContext = context.HttpContext.RequestServices.GetRequiredService<BloggingContext>();
           var blogs = await dbContext.Blogs.ToListAsync();
           if (!true)
           {
               throw new SecurityTokenValidationException($"Tenant xxxxx is not registered");
           }
         
       };
