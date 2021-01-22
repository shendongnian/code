    public static X CreateY_New()
    {
      return new Y();
    }
    public static X CreateY_CreateInstance()
    {
      return (X)Activator.CreateInstance(typeof(Y));
    }
    public static X CreateY_CreateInstance_String()
    {
      return (X)Activator.CreateInstance("Program", "Y").Unwrap();
    }
    static readonly System.Reflection.ConstructorInfo YConstructor = 
        typeof(Y).GetConstructor(Type.EmptyTypes);
    static readonly object[] Empty = new object[] { };
    public static X CreateY_Invoke()
    {
      return (X)YConstructor.Invoke(Empty);
    }
    static readonly Func<X> YCreator = Expression.Lambda<Func<X>>(
       Expression.New(typeof(Y).GetConstructor(Type.EmptyTypes))
     ).Compile();
    public static X CreateY_CompiledExpression()
    {
      return YCreator();
    }
    static void Main(string[] args)
    {
      const int iterations = 5000000;
      Console.WriteLine("Iterations: {0}", iterations);
      foreach (var creatorInfo in new [] 
        { 
          new {Name = "Activator.CreateInstance(string, string)", Creator = (Func<X>)CreateY_CreateInstance},
          new {Name = "Activator.CreateInstance(type)", Creator = (Func<X>)CreateY_CreateInstance},
          new {Name = "ConstructorInfo.Invoke", Creator = (Func<X>)CreateY_Invoke},
          new {Name = "Compiled expression", Creator = (Func<X>)CreateY_CompiledExpression},
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
    }
    public class X
    {
      public X() { }
      public X(int z) { this.Z = z; }
      public int Z;
    }
    public class Y : X { }
