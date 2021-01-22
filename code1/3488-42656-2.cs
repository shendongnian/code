    using System.Linq;  
    class DoubleDispatch
     { public T Foo<T>(object arg)
        { var method = from m in GetType().GetMethods()
                       where    m.Name == "Foo" 
                             && m.GetParameters().Length==1
                             && arg.GetType().IsAssignableFrom
                                               (m.GetParameters()[0].GetType())
                             && m.ReturnType == typeof(T)
                       select m;
                               
          return (T) method.Single().Invoke(this,new object[]{arg});          
        }
       public int Foo(int arg) { /* ... */ }
       static void Test() 
        { object x = 5;
          Foo<int>(x); //should call Foo(int) via Foo<T>(object).
        }
     }       
