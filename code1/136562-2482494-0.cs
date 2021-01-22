    class Program
    {
        static void Main()
        {
            Foo(new MyType { Name = "abc", Description = "def" });
        }
        static void Foo<T>(T val) where T : IMyType {
            var expressions = new Expression<Action<T, StringBuilder>>[] {
                    (t, sb) => sb.Append(t.Name),
                    (t, sb) => sb.Append(", "),
                    (t, sb) => sb.Append(t.Description)
            };
            Action<T, StringBuilder> result = null;
            foreach (var expr in expressions) result += expr.Compile();
            if (result == null) result = delegate { };
            // now test it
            StringBuilder sbInst = new StringBuilder();
            result(val, sbInst);
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
