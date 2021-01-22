     public override TR Create<T, TR>(T entity)
        {
            string entitySet = GetEntitySetName<T>();
            _context.AddObject(entitySet, entity);
            _context.SaveChanges();
            
            //Returns primaryKey value
            return (TR)context.CreateEntityKey(entitySet, entity).EntityKeyValues[0].Value;                       
        }
