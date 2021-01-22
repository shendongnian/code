    public interface IFoo
    {
      string Name{get;set;}
      Type FooType{get;set;}
    }
    public class FooWithStuff<T>:IFoo
    {
       T Value {get;set;}
    }
