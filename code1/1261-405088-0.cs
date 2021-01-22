     interface IFoo<T>
      { T Bar {get;}
      }
     class MyFoo<T> : IFoo<T> 
      { public MyFoo(T t) {Bar = t;}
        public T Bar {get; private set;} 
      }
     static class Foo 
      { public static IFoo<T> ToFoo<T>(this T t) {return new MyFoo<T>(t);}
      
        public static void Do<T>(this T t, Action<T> a) { a(t);}
      
        public static IFoo<U> Select<T,U>(this IFoo<T> foo, Func<T,U> f) 
         { return f(foo.Bar).ToFoo();
         }
      }
     /* ... */
     using (var file = File.OpenRead("objc.h"))
     { var x = from f in file.ToFoo()
               let s = new Scanner(f)
               let p = new Parser {scanner = s}
               select p.Parse();
             
       x.Do(p => 
        { /* drop into imperative code to handle file 
             in Foo monad if necessary */      
        });
      
     }
