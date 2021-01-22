    public class SimpleFactory
    {
     public static ITest Create<T>()
        where T: IConcreteTest, new()
     {
        return new T();
     }
    }
