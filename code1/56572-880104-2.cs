        static void Update<TEntity>(DataContext dataContext, int id, TEntity obj)
            where TEntity : class
        {
            Update<TEntity, int>(dataContext, id, obj);
        }
        static void Update<TEntity, TKey>(DataContext dataContext, TKey id, TEntity obj)
            where TEntity : class
        {
            // get the row from the database using the meta-model
            MetaType meta = dataContext.Mapping.GetTable(typeof(TEntity)).RowType;
            if(meta.IdentityMembers.Count != 1) throw new InvalidOperationException("Composite identity not supported");
            string idName = meta.IdentityMembers[0].Member.Name;
            var param = Expression.Parameter(typeof(TEntity), "row");
            var lambda = Expression.Lambda<Func<TEntity,bool>>(
                Expression.Equal(
                    Expression.PropertyOrField(param, idName),
                    Expression.Constant(id, typeof(TKey))), param);
            object dbRow = dataContext.GetTable<TEntity>().Single(lambda);
            foreach (MetaDataMember member in meta.DataMembers)
            {
                // don't copy ID or timstamp/rowversion
                if (member.IsPrimaryKey || member.IsVersion) continue;
                // (perhaps exclude associations too)
                // if you get problems, try using StorageAccessor instead -
                // this will typically skip validation, etc
                member.MemberAccessor.SetBoxedValue(
                    ref dbRow, member.MemberAccessor.GetBoxedValue(obj));
            }
            // submit changes here?
        }
