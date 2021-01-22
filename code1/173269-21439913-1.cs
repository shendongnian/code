    var processing= new ConcurrentQueue<int>();
    //possible multi threaded enumeration only processed non-queued records
    Parallel.ForEach(dataEnumeration, dataItem=>
    {
         if(!processing.Contains(dataItem.Id))
         {
             processing.Enqueue(dataItem.Id);
              var myEntityResource = new EntityResource();
              myEntityResource.EntityRecords.Add(new EntityRecord
                                          {
                                            Field1="Value1", 
                                            Field2="Value2"
                                          }
                                   );
              
               SaveContext(myEntityResource);
           var itemIdProcessed = 0;
           processing.TryDequeue(out itemIdProcessed );
               
         }
    }
    public void RefreshContext(DbContext context)
        {
            var modifiedEntries = context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified || e.State == EntityState.Deleted);
            foreach (var modifiedEntry in modifiedEntries)
            {
                modifiedEntry.Reload();
            }
        }
    public bool SaveContext(DbContext context,out Exception error, bool reloadContextFirst = true)
        {
            error = null;
            var saved = false;
            try
            {
                if (reloadContextFirst)
                    this.RefreshContext(context);
                context.SaveChanges();
                saved = true;
            }
            catch (OptimisticConcurrencyException)
            {
                //retry saving on concurrency error
                if (reloadContextFirst)
                    this.RefreshContext(context);
                context.SaveChanges();
                saved = true;
            }
            catch (DbEntityValidationException dbValEx)
            {
                var outputLines = new StringBuilder();
                foreach (var eve in dbValEx.EntityValidationErrors)
                {
                    outputLines.AppendFormat("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:",
                        DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.AppendFormat("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw new DbEntityValidationException(string.Format("Validation errors\r\n{0}", outputLines.ToString()), dbValEx);
            }
            catch (Exception ex)
            {
                error = new Exception("Error saving changes to the database.", ex);
            }
            return saved;
        }
