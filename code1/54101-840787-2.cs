    public class SimpleFactory
    {
     public static ITest Create<T>()
        where T: ITest, new()
     {
        return new T();
     }
    }
