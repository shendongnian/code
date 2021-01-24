    protected void base_UpdateCommand(IDbCommand myCommand, TEntity entity, string sWhere)
    {
        var properties = (typeof(TEntity)).GetProperties().ToList();
    
        foreach (var prop in properties)
        {
            bool bIgnore = prop.GetCustomAttributes(true).Any(a => a is KeyAttribute);
            if (prop.Name.ToUpper() != sKeyField.ToUpper() && !bIgnore)
            {
                sProps = sProps + prop.Name + "=@" + prop.Name + ", ";                    
            }
        }
    }
