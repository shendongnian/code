    public interface IModel<T>
    {
       void Dosomething(T model);
    }
----
    public class ImplementationB : IModel<B>
    {
       public void Dosomething(B model)
        {
          Console.WriteLine(model.someID);
        }
    }
