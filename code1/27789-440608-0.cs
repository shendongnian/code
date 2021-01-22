        static TItem GetQuery<TItem, TKey>(TKey key) where TItem : class
        {
            DataContext ctx = null;
            var table = ctx.GetTable<TItem>();
            var primaryKey = ctx.Mapping.GetMetaType(typeof(TItem)).DataMembers.Where(
                member => member.IsPrimaryKey).Single().Member.Name;
            var item = Expression.Parameter(typeof(TItem), "item");
            var lambda = Expression.Lambda<Func<TItem, bool>>(
                Expression.Equal(
                    Expression.PropertyOrField(item, primaryKey),
                    Expression.Constant(key, typeof(TKey))));
            return table.Single(lambda);
        }
