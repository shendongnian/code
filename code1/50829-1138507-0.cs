    public T GetInstanceByPrimaryKey<T>(object primaryKeyValue) where T : class
    {
        var table = this.GetTable<T>();
        var mapping = this.Mapping.GetTable(typeof(T));
        var pkfield = mapping.RowType.DataMembers.SingleOrDefault(d => d.IsPrimaryKey);
    
        if (pkfield == null)
            throw new Exception(String.Format("Table {0} does not contain a Primary Key field", mapping.TableName));
    
        var param = Expression.Parameter(typeof(T), "e");
    
        var predicate =
            Expression.Lambda<Func<T, bool>>(Expression.Equal(Expression.Property(param, pkfield.Name), Expression.Constant(primaryKeyValue)), param);
    
        return table.SingleOrDefault(predicate);
    }
