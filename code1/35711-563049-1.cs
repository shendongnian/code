    public class Foo<T> : IFoo<T>
    {
       private T value;
       public Foo(string name, T value)
       {
         this.name = name;
         this.value = value;
       }
    
       public string Name { get { return name; } }
       public Type Type { get { return typeof(T); } }
       public T Value
       {
          get { return value; }
          set { value = value; }
       }
    
       object IFoo.Value
       {
          get { return value; }
          set { value = (T)value; }  // can check type before
       }
    }
