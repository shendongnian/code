    public bool Edit(WorkshopReport updated)
            {
                try
                {
                    var local = _ctx.Set<WorkshopReport>()
                        .Local
                        .FirstOrDefault(f => f.Id == updated.Id);
                    if (local != null)
                    {
                        _ctx.Entry(local).State = EntityState.Detached;
                    }
                    _ctx.Entry(updated).State = System.Data.Entity.EntityState.Modified;
                    return true;
                }
                catch (Exception ex)
                {
                    // TODO log this error
                    return false;
                }
            }
