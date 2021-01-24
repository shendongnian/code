        public Result Update(string environment, User item)
        {
            ObjectContext objectContext = WCF_Service_Library.Classes.Common.getObjectContext(environment, false);
            try
            {
                var entityItem = objectContext.CreateObjectSet<User>()
                    .AsEnumerable().Where(Item => Item.ID == item.ID).ToList().FirstOrDefault();
                if (entityItem == null)
                    return new Result("Item does NOT exist in the database!");
                entityItem = Common.CopyValuesFromSourceToDestinationForUpdate(item, entityItem) as User;
                objectContext.SaveChanges();
                return new Result(entityItem.ID);
            }
            catch (Exception exception)
            {
                return new Result("Service Error: " + Common.getInnerExceptionMessage(exception));
            }
        }
