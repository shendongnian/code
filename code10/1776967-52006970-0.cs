     public static class DbContextExtensions
        {
            public static void EnsureIdUpdates(this DbContext context)
            {
                 //CHOOSE HERE if you want to execute a sql script using Context.Set<YourEntity>().FromSql   
                 //OR
                
                //Do here a check to ensure that this method will be called just once as part of your migrations, for example if you ran this code before, you would be able to check that some records has an Id != 0 and you don't need to update the Ids again
                var dataToUpdate = context.Set<YourEntity>();
                int count = 0;
                dataToUpdate.ForEachAsync(x => { x.Id = count++; }).Wait();
                context.SaveChanges();
         }
    }
