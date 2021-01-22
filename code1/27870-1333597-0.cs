    Blog blog = new Blog            
    {                
       Name = blogName,                
       Slogan = slogan,                
       UsersReference.EntityKey = new EntityKey("EntityModel.Users", "UserId", userId)            
    }
    Entities.AddToBlogs(blog);
    Entities.SaveChanges();
