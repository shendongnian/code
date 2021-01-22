        public static TItem Get<TItem, TKey>(
            this DataContext ctx, TKey key)
            where TItem : class
        {
            var table = ctx.GetTable<TItem>();
            var primaryKey = ctx.Mapping.GetMetaType(typeof(TItem))
                    .DataMembers.Where(
                member => member.IsPrimaryKey).Single().Member.Name;
            var item = Expression.Parameter(typeof(TItem), "item");
            var lambda = Expression.Lambda<Func<TItem, bool>>(
                Expression.Equal(
                    Expression.PropertyOrField(item, primaryKey),
                    Expression.Constant(key, typeof(TKey))),
                    item);
            return table.Single(lambda);
        }
        public static TItem Get<TItem>( // common case
            this DataContext ctx, int key)
            where TItem : class
        {
            return Get<TItem, int>(ctx, key);
        }
        public static TItem Get<TItem>( // common case
           this DataContext ctx, string key)
           where TItem : class
        {
            return Get<TItem, string>(ctx, key);
        }
