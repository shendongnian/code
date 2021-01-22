    static class ObjDiffCollector<T>
    {
        private delegate DiffEntry DiffDelegate(T x, T y);
        private static readonly IReadOnlyDictionary<string, DiffDelegate> DicDiffDels;
        private static PropertyInfo PropertyOf<TClass, TProperty>(Expression<Func<TClass, TProperty>> selector)
            => (PropertyInfo)((MemberExpression)selector.Body).Member;
        static ObjDiffCollector()
        {
            var expParamX = Expression.Parameter(typeof(T), "x");
            var expParamY = Expression.Parameter(typeof(T), "y");
            var propDrName = PropertyOf((DiffEntry x) => x.Prop);
            var propDrValX = PropertyOf((DiffEntry x) => x.ValX);
            var propDrValY = PropertyOf((DiffEntry x) => x.ValY);
            var dic = new Dictionary<string, DiffDelegate>();
            var props = typeof(T).GetProperties();
            foreach (var info in props)
            {
                var expValX = Expression.MakeMemberAccess(expParamX, info);
                var expValY = Expression.MakeMemberAccess(expParamY, info);
                var expEq = Expression.Equal(expValX, expValY);
                var expNewEntry = Expression.New(typeof(DiffEntry));
                var expMemberInitEntry = Expression.MemberInit(expNewEntry,
                    Expression.Bind(propDrName, Expression.Constant(info.Name)),
                    Expression.Bind(propDrValX, Expression.Convert(expValX, typeof(object))),
                    Expression.Bind(propDrValY, Expression.Convert(expValY, typeof(object)))
                );
                var expReturn = Expression.Condition(expEq
                    , Expression.Convert(Expression.Constant(null), typeof(DiffEntry))
                    , expMemberInitEntry);
                var expLambda = Expression.Lambda<DiffDelegate>(expReturn, expParamX, expParamY);
                var compiled = expLambda.Compile();
                dic[info.Name] = compiled;
            }
            DicDiffDels = dic;
        }
        public static DiffEntry[] Diff(T x, T y)
        {
            var list = new List<DiffEntry>(DicDiffDels.Count);
            foreach (var pair in DicDiffDels)
            {
                var r = pair.Value(x, y);
                if (r != null) list.Add(r);
            }
            return list.ToArray();
        }
    }
    class DiffEntry
    {
        public string Prop { get; set; }
        public object ValX { get; set; }
        public object ValY { get; set; }
    }
