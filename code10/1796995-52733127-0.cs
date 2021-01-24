    public bool SaveDataCapDetails(List<TDataCapDetails> lstDataCapDetails)
        {
            bool IsSuccess = false;
            using (var dbContextTransaction = _objContext.Database.BeginTransaction())
            {
                try
                {
                    int? id = _objContext.TDataCapDetails.Max(x => (int?)x.Id);
                    id = id == null ? 0 : id;
                    // entities with Id == 0 --> new entities
                    // you may need to check if Id == null as well (depends on your data model)
                    var entitiesToAdd = lstDataCapDetails.Where(x => x.Id == 0);
                    foreach(var entity in entitiesToAdd)
                    {
                        entity.Id = id++;
                        // new entities is not tracked, its state can be changed to Added
                        _objContext.Entry(entity).State = EntityState.Added;
                    }
                    // entities with Id > 0 is already exists in db and needs to be updated
                    var entitiesToUpdate = lstDataCapDetails.Where(x => x.Id > 0);
                    foreach (var entity in entitiesToUpdate)
                    {
                        // check if entity is being tracked
                        var local = _objContext.Set<TDataCapDetails>().Local.FirstOrDefault(x => x.Id.Equals(entity.Id));
                        // if entity is tracked detach it from context
                        if (local != null)
                            _objContext.Entry<TDataCapDetails>(local).State = EntityState.Detached;
                        // attach modified entity and change its state to modified
                        _objContext.Attach(entity).State = EntityState.Modified;
                    }
                    // optional: assign value for IsSuccess
                    IsSuccess = _objContext.SaveChanges() > 0;                    
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw ex;
                }
            }
            return IsSuccess;
        }
