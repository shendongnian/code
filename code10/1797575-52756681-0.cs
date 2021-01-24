    protected override System.Data.Entity.Validation.DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, System.Collections.Generic.IDictionary<object, object> items)
    {
        if (entityEntry.Entity is Student)
        {
            if (entityEntry.CurrentValues.GetValue<string>("StudentName") == "")
            {
                var list = new List<System.Data.Entity.Validation.DbValidationError>();
                list.Add(new System.Data.Entity.Validation.DbValidationError("StudentName", "StudentName is required"));
    
                return new System.Data.Entity.Validation.DbEntityValidationResult(entityEntry, list);
            }
        }
        return base.ValidateEntity(entityEntry, items);
    }
