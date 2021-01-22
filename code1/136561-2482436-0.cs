    class Program
    {
        static void Main()
        {
            Foo(new MyType { Name = "abc", Description = "def" });
        }
        static void Foo<T>(T val) where T : IMyType
        {
            var expressions = new Expression<Func<T, StringBuilder, StringBuilder>>[] {
                    (t, sb) => sb.Append(t.Name),
                    (t, sb) => sb.Append(", "),
                    (t, sb) => sb.Append(t.Description)
            };
            var tparam = Expression.Parameter(typeof(T), "t");
            var sbparam = Expression.Parameter(typeof(StringBuilder), "sb");
            Expression body = sbparam;
            for (int i = 0; i < expressions.Length; i++)
            {
                body = Expression.Invoke(expressions[i], tparam, body);
            }
            var func = Expression.Lambda<Func<T, StringBuilder, StringBuilder>>(
                body, tparam, sbparam).Compile();
            
            // now test it
            StringBuilder sbInst = new StringBuilder();
            func(val, sbInst);
            Console.WriteLine(sbInst.ToString());
        }
    }
    public class MyType : IMyType
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    interface IMyType
    {
        string Name { get; }
        string Description { get; }
    }
