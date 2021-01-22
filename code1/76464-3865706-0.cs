    class myClass {
      private delegate string myDelegate(Object bj);
      protected void method() {
        myDelegate build = delegate(Object obj) {
          // f is the function itself, which is passed into the function
          return Functional.Y<Object, string>(f => bj => { 
            var letters = string.Empty;
            if (someCondition)
              return f(some_obj);
            else return string.Empty;
          })(obj);
        };
      }
    }
    public static class Functional {
      public delegate Func<A, R> Recursive<A, R>(Recursive<A, R> r);
      public static Func<A, R> Y<A, R>(Func<Func<A, R>, Func<A, R>> f) {
        Recursive<A, R> rec = r => a => f(r(r))(a);
        return rec(rec);
      }
    }
