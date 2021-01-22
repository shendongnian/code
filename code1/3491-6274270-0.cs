    class DoubleDispatch
    {
        public T Foo<T>(object arg)
        {
            var method = from m in GetType().GetMethods(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic)
                         where m.Name == "Foo"
                               && m.GetParameters().Length == 1
                               //&& arg.GetType().IsAssignableFrom
                               //                  (m.GetParameters()[0].GetType())
                               &&Type.GetType(m.GetParameters()[0].ParameterType.FullName).IsAssignableFrom(arg.GetType())
                               && m.ReturnType == typeof(T)
                         select m;
           
            return (T)method.Single().Invoke(this, new object[] { arg });
        }
        public int Foo(int arg)
        {
            return 10;
        }
        public string Foo(string arg)
        {
            return 5.ToString();
        }
        public static void Main(string[] args)
        {
            object x = 5;
            DoubleDispatch dispatch = new DoubleDispatch();
            Console.WriteLine(dispatch.Foo<int>(x));
            Console.WriteLine(dispatch.Foo<string>(x.ToString()));
            Console.ReadLine();
        }
    }
