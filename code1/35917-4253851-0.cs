    public class Foo {
    
       public Foo(Func<MyObj, MyObj> map) {... }
    
    }
    
    public class Client {
    
       private static T Identity<T>(T t) { return t; }
    
       public void main() {
          var foo = new Foo(Identity);
          var c = from f in Enumerable.Range(0, 100) select Identity(f);
          c.ToList().ForEach(System.Console.Out.WriteLine);
       }
    }
