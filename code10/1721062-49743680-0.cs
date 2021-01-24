    public class ParentClass<T> {
          public T ItemValue { get; set; }
    ...
    }
    public class ChildClass : ParentClass<ChildClass> 
    {
      ...
    }
           
