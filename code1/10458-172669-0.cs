    public class MyClass<T>
    {
     ...
    }
    
    public class IntClass : MyClass<int>
    {
      public void IncrementMe()
      {
        this.value++;
      }
    }
