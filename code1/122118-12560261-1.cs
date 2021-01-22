        using(DatabaseContext context = new DatabaseContext)
        {
            Link linkToDelete = context.Links.FirstOrDefault(); 
            if(linkToDelete != null)
            {
                context.Links.Remove(linkToDelete);
                context.SaveChanges();
            }
        }
