        public virtual void Update(DataContext dataContext, TLinqEntity obj)
        {
            // get the row from the database using the meta-model
            MetaType meta = dataContext.Mapping.GetTable(typeof(TLinqEntity)).RowType;
            if (meta.IdentityMembers.Count != 1)
                throw new InvalidOperationException("Composite identity not supported");
            string idName = meta.IdentityMembers[0].Member.Name;
            var id = obj.GetType().GetProperty(idName).GetValue(obj, null);
            var param = Expression.Parameter(typeof(TLinqEntity), "row");
            var lambda = Expression.Lambda<Func<TLinqEntity, bool>>(
                Expression.Equal(
                    Expression.PropertyOrField(param, idName),
                    Expression.Constant(id, typeof(int))), param);
            object dbRow = dataContext.GetTable<TLinqEntity>().Single(lambda);
            foreach (MetaDataMember member in meta.DataMembers)
            {
                // don't copy ID or timstamp/rowversion
                if (member.IsPrimaryKey || member.IsVersion) continue;
                // (perhaps exclude associations too)
                member.MemberAccessor.SetBoxedValue(
                    ref dbRow, member.MemberAccessor.GetBoxedValue(obj));
            }
            dataContext.SubmitChanges();
        }
