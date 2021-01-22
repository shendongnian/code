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
            TEntity dbRow = dataContext.GetTable<TEntity>().Single(lambda);
            foreach (MetaDataMember member in meta.DataMembers)
            {
                // don't copy ID or timstamp/rowversion
                if (member.IsPrimaryKey || member.IsVersion) continue;
                // (perhaps exclude associations too)
                switch (member.StorageMember.MemberType)
                {
                    case MemberTypes.Field:
                        FieldInfo fi = (FieldInfo)member.StorageMember;
                        fi.SetValue(dbRow, fi.GetValue(obj));
                        break;
                    case MemberTypes.Property:
                        PropertyInfo pi = (PropertyInfo)member.StorageMember;
                        pi.SetValue(dbRow, pi.GetValue(obj, null), null);
                        break;
                    default: throw new NotSupportedException(member.StorageMember.MemberType.ToString());
                }
            }
            // submit changes here?
        }
