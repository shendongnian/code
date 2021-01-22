    static void Main(string[] args)
    {
        IUnityContainer container = new UnityContainer();
        container.RegisterType<Type1>();
        container.RegisterInstance<Type2>(new Type2());
        Type1 t = container.Resolve<Type1>();
        Type2 t2 = container.Resolve<Type2>();
        Type3 t3 = container.Resolve<Type3>();
        Console.ReadKey();
    }
    public class Type1
    {
    }
    public class Type2
    {
    }
    public class Type3
    {
        private Type1 t;
        private Type2 t2;
        public Type3(Type1 t, Type2 t2)
        {
            this.t = t;
            this.t2 = t2;
        }
    }
