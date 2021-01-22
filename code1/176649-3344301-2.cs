    public class Service1 : IService1
    {
       public Foo<string> GetData()
       {
           return new Foo<string>() { Value = "My test string" };
       }
    }
