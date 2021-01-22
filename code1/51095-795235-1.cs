        public void AddMapping<TSource, TValue>(
            Control control,
            TSource source,
            Expression<Func<TSource, TValue>> mapping)
        {
            if (mapping.Body.NodeType != ExpressionType.MemberAccess)
            {
                throw new InvalidOperationException();
            }
            MemberExpression me = (MemberExpression)mapping.Body;
            if (me.Expression != mapping.Parameters[0])
            {
                throw new InvalidOperationException();
            }
            string name = me.Member.Name;
            // TODO: do something with "control", "source" and "name",
            // maybe also using "me.Member"
        }
