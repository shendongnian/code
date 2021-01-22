    public interface IMyClass {
      object Value { get; set; }
    }
    public class MyClass<T> : IMyClass {
      public T Value { get; set; }
      object IMyClass.Value {
        get { return Value; }
        set { Value = (T)value; }
      }
    }
    List<IMyClass> m = new List<IMyClass> { new MyClass<string>(), new MyClass<int> };
