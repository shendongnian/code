    public sealed class SingletonClass
    {
       
     SingletonClass()
        {
        }
    public static SingletonClass Instance
    {
        get
        {
            return InnerClass.instance;
        }
    }
    
    class InnerClass
    {
        static InnerClass()
        {
        }
        internal static readonly SingletonClass instance = new SingletonClass();
    }
}
