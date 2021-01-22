    public class Base<T> : Inx<T> where T : new()
    {
       public T Set(Data data) {
           T t = new T();
           ///
           return t;
       }
    }
    public class Parent : Base<Parent> { }
