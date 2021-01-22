    // I changed this with respect to ShuggyCoUk's answer (Kudos!)
    class LazyEval<T>
    {
      T value;
      Func<T> eval;
      public LazyEval(Func<T> eval) { this.eval = eval; }
      public T Eval()
      {
          if (eval == null)
              return value;
          value = eval();
          eval = null;
          return value;
      }
      public static implicit operator T(LazyEval<T> lazy) // possibly make explicit
      {
        return lazy.Eval();
      }
      public static implicit operator LazyEval<T>(Func<T> eval) 
      {
        return new LazyEval(eval);
      } 
    }
    // option 5
    class Foo
    {
        public LazyEval<MyClass> LazyProperty { get; private set; }
        public Foo()
        {
            LazyProperty = () => new MyClass();
        }
    }
