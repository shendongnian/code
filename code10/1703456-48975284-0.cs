    public void AppendValidationErrors(Exception e)
    {
        DbEntityValidationException ex = e is DbEntityValidationException ?
            e as DbEntityValidationException : null ;
    
        if (ex == null) { log.Info(e); return; }
    
        foreach (var eve in ex.EntityValidationErrors)
        {
            log.Info(string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                eve.Entry.Entity.GetType().Name, eve.Entry.State));
    
            foreach (var ve in eve.ValidationErrors)
            {
                log.Info(string.Format("- Property: \"{0}\", Error: \"{1}\"",
                    ve.PropertyName, ve.ErrorMessage));
            }
        }
    }
