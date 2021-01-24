    public static class Tools
    {
        public static void CopyFrom<T>(this T target, T source, params string[] properties)
        {
            ToolsImpl<T>.CopyTo(source, target, properties);
        }
        private static class ToolsImpl<T>
        {
            public static readonly Action<T, T, string[]> CopyTo;
            static ToolsImpl()
            {
                var source = Expression.Parameter(typeof(T), "s");
                var target = Expression.Parameter(typeof(T), "t");
                var properties = Expression.Parameter(typeof(string[]), "properties");
                // indexer of the for cycle
                var i = Expression.Variable(typeof(int), "i");
                // case "prop1": target.prop1 = source.prop1
                var cases = typeof(T)
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(x => x.CanRead && x.CanWrite && x.GetIndexParameters().Length == 0)
                    .Select(x => Expression.SwitchCase(Expression.Assign(Expression.Property(target, x), Expression.Property(source, x)), Expression.Constant(x.Name)));
                // switch properties[i]:
                var sw = Expression.Switch(typeof(void), Expression.ArrayAccess(properties, i), null, null, cases);
                var lblForBegin = Expression.Label(typeof(void), "for begin");
                var lblForCheck = Expression.Label(typeof(void), "for check");
                // we simulate a for (int i = 0; i < properties.Length; ++i
                var body = Expression.Block(new[] { i },
                    new Expression[]
                    {
                        Expression.Assign(i, Expression.Constant(0)), // ix = 0
                        Expression.Goto(lblForCheck), // goto lblForCheck
                        Expression.Label(lblForBegin), // :lblForBegin
                        sw, // switch ()
                        Expression.PreIncrementAssign(i), // ++i
                        Expression.Label(lblForCheck), // :lblForCheck
                        Expression.IfThen(Expression.LessThan(i, Expression.ArrayLength(properties)), Expression.Goto(lblForBegin)), // if ix < properties.Length goto lblForBegin
                    });
                var exp = Expression.Lambda<Action<T, T, string[]>>(body, source, target, properties);
                CopyTo = exp.Compile();
            }
        }
    }
