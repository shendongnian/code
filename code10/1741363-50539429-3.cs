       var photo = new Photo 
       {
          Title = "Title1",
          Description = "Description1",
          CreatedDate = DateTime.Today,
          Comments = new[] 
          {
             New Comment { UserName = "User1", Subject = "Comment1" }
          }.ToList()
       };
       context.Photos.Add(photo);
       context.SaveChanges();
      
