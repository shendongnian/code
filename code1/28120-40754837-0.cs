    public static void UpdateOnSubmit<TEntity>(this Table<TEntity> table, TEntity entity, TEntity original = null)
        where TEntity : class, new()
    {
        if (original == null)
        {
            // Create original object with only primary keys set
            original = new TEntity();
            var entityType = typeof(TEntity);
            var dataMembers = table.Context.Mapping.GetMetaType(entityType).DataMembers;
            foreach (var member in dataMembers.Where(m => m.IsPrimaryKey))
            {
                var propValue = entityType.GetProperty(member.Name).GetValue(entity, null);
                entityType.InvokeMember(member.Name, BindingFlags.SetProperty, Type.DefaultBinder,
                    original, new[] { propValue });
            }
        }
        // This will update all columns that are not set in 'original' object. For
        // this to work, entity has to have UpdateCheck=Never for all properties except
        // for primary keys. This will update the record without querying it first.
        table.Attach(entity, original);
    }
