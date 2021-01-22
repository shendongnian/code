    static class ComExample {
        static void Main()
        {
            using (var wrapper = new ReleaseWrapper())
            {
                var baz = wrapper.Add(
                    () => new Foo().Bar.Baz);
                Console.WriteLine(baz.Name);
            }
        }
    }
    class ReleaseWrapper : IDisposable
    {
        List<object> objects = new List<object>();
        public T Add<T>(Expression<Func<T>> func)
        {
            return (T)Walk(func.Body);
        }
        object Walk(Expression expr)
        {
            object obj = WalkImpl(expr);
            if (obj != null && Marshal.IsComObject(obj)
                  && !objects.Contains(obj)) { objects.Add(obj); }
            return obj;
        }
        object WalkImpl(Expression expr)
        {
            switch (expr.NodeType)
            {
                case ExpressionType.Constant:
                    return ((ConstantExpression)expr).Value;
                case ExpressionType.New:
                    NewExpression ne = (NewExpression)expr;
                    object[] args = ne.Arguments.Select(arg => Walk(arg)).ToArray();
                    return ne.Constructor.Invoke(args);
                case ExpressionType.MemberAccess:
                    MemberExpression me = (MemberExpression)expr;
                    object target = Walk(me.Expression);
                    switch (me.Member.MemberType)
                    {
                        case MemberTypes.Field:
                            return ((FieldInfo)me.Member).GetValue(target);
                        case MemberTypes.Property:
                            return ((PropertyInfo)me.Member).GetValue(target, null);
                        default:
                            throw new NotSupportedException();
    
                    }
                default:
                    throw new NotSupportedException();
            }
        }
        public void Dispose()
        {
            foreach(object obj in objects) {
                Marshal.ReleaseComObject(obj);
                Debug.WriteLine("Released: " + obj);
            }
            objects.Clear();
        }
    }
