    static X CreateY_New()
    {
        return new Y();
    }
    static X CreateY_New_Arg(int z)
    {
        return new Y(z);
    }
    static X CreateY_CreateInstance()
    {
        return (X)Activator.CreateInstance(typeof(Y));
    }
    static X CreateY_CreateInstance_String()
    {
        return (X)Activator.CreateInstance("Program", "Y").Unwrap();
    }
    static X CreateY_CreateInstance_Arg(int z)
    {
        return (X)Activator.CreateInstance(typeof(Y), new object[] { z, });
    }
    private static readonly System.Reflection.ConstructorInfo YConstructor =
        typeof(Y).GetConstructor(Type.EmptyTypes);
    private static readonly object[] Empty = new object[] { };
    static X CreateY_Invoke()
    {
        return (X)YConstructor.Invoke(Empty);
    }
    private static readonly System.Reflection.ConstructorInfo YConstructor_Arg =
        typeof(Y).GetConstructor(new[] { typeof(int), });
    static X CreateY_Invoke_Arg(int z)
    {
        return (X)YConstructor_Arg.Invoke(new object[] { z, });
    }
    private static readonly Func<X> YCreator = Expression.Lambda<Func<X>>(
       Expression.New(typeof(Y).GetConstructor(Type.EmptyTypes))
    ).Compile();
    static X CreateY_CompiledExpression()
    {
        return YCreator();
    }
    private static readonly Func<X> YCreator_Type = Expression.Lambda<Func<X>>(
       Expression.New(typeof(Y))
    ).Compile();
    static X CreateY_CompiledExpression_Type()
    {
        return YCreator_Type();
    }
    private static readonly ParameterExpression YCreator_Arg_Param = Expression.Parameter(typeof(int), "z");
    private static readonly Func<int, X> YCreator_Arg = Expression.Lambda<Func<int, X>>(
       Expression.New(typeof(Y).GetConstructor(new[] { typeof(int), }), new[] { YCreator_Arg_Param, }),
       YCreator_Arg_Param
    ).Compile();
    static X CreateY_CompiledExpression_Arg(int z)
    {
        return YCreator_Arg(z);
    }
    static void Main(string[] args)
    {
        const int iterations = 5000000;
        Console.WriteLine("Iterations: {0}", iterations);
        Console.WriteLine("No args");
        foreach (var creatorInfo in new[]
        {
            new {Name = "Activator.CreateInstance(string assemblyName, string typeName)", Creator = (Func<X>)CreateY_CreateInstance},
            new {Name = "Activator.CreateInstance(Type type)", Creator = (Func<X>)CreateY_CreateInstance},
            new {Name = "ConstructorInfo.Invoke", Creator = (Func<X>)CreateY_Invoke},
            new {Name = "Compiled expression", Creator = (Func<X>)CreateY_CompiledExpression},
            new {Name = "Compiled expression (type)", Creator = (Func<X>)CreateY_CompiledExpression_Type},
            new {Name = "new", Creator = (Func<X>)CreateY_New},
        })
        {
            var creator = creatorInfo.Creator;
            var sum = 0;
            for (var i = 0; i < 1000; i++)
                sum += creator().Z;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (var i = 0; i < iterations; ++i)
            {
                var x = creator();
                sum += x.Z;
            }
            stopwatch.Stop();
            Console.WriteLine("{0}, {1}", stopwatch.Elapsed, creatorInfo.Name);
        }
        Console.WriteLine("Single arg");
        foreach (var creatorInfo in new[]
        {
            new {Name = "Activator.CreateInstance(Type type)", Creator = (Func<int, X>)CreateY_CreateInstance_Arg},
            new {Name = "ConstructorInfo.Invoke", Creator = (Func<int, X>)CreateY_Invoke_Arg},
            new {Name = "Compiled expression", Creator = (Func<int, X>)CreateY_CompiledExpression_Arg},
            new {Name = "new", Creator = (Func<int, X>)CreateY_New_Arg},
        })
        {
            var creator = creatorInfo.Creator;
            var sum = 0;
            for (var i = 0; i < 1000; i++)
                sum += creator(i).Z;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (var i = 0; i < iterations; ++i)
            {
                var x = creator(i);
                sum += x.Z;
            }
            stopwatch.Stop();
            Console.WriteLine("{0}, {1}", stopwatch.Elapsed, creatorInfo.Name);
        }
    }
    public class X
    {
      public X() { }
      public X(int z) { this.Z = z; }
      public int Z;
    }
    public class Y : X
    {
        public Y() {}
        public Y(int z) : base(z) {}
    }
