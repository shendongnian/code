        public static string GetProperty<TContext, TValue>(
            this TContext ctx, Expression<Func<TContext, TValue>> selector,
            string propertyName)
            where TContext : DataContext
        {
            MemberExpression me = selector.Body as MemberExpression;
            if (me == null) throw new InvalidOperationException();
            var member = me.Member;
            var objType = me.Expression.Type;
            var metaType = ctx.Mapping.GetMetaType(objType);
            string tableName = metaType.Table.TableName;
            string columnName = metaType.GetDataMember(member).MappedName;
            return ctx.GetProperty(tableName, columnName, propertyName);
        }
