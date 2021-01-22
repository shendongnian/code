    public class MyExtremelySimpleFactoryExampleClass
    {
      public IEntity Instantiate()
      {
        return new Product();
      }
    }
    
    // elsewhere in your code...
    var item = myFactory.Instantiate(); // item is of type IEntity
