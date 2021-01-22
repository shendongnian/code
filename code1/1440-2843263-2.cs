        public class StaticConstrucEx2Outer<T> {
     
     // Will hold a different value depending on the specicified generic type
     public T SomeProperty { get; set; }
    
     static StaticConstrucEx2Outer() {
      Console.WriteLine("StaticConstrucEx2Outer " + typeof(T).Name);
     }
    
     public class StaticConstrucEx2Inner<U, V> {
    
      static StaticConstrucEx2Inner() {
    
       Console.WriteLine("Outer <{0}> : Inner <{1}><{2}>",
        typeof(T).Name,
        typeof(U).Name,
        typeof(V).Name);
      }
    
      public static void FooBar() {}
     }
    
     public class SCInner {
    
      static SCInner() {
       Console.WriteLine("SCInner init <{0}>", typeof(T).Name);
      }
    
      public static void FooBar() {}
     }
    }
    StaticConstrucEx2Outer<int>.StaticConstrucEx2Inner<string, DateTime>.FooBar();
    StaticConstrucEx2Outer<int>.SCInner.FooBar();
    
    StaticConstrucEx2Outer<string>.StaticConstrucEx2Inner<string, DateTime>.FooBar();
    StaticConstrucEx2Outer<string>.SCInner.FooBar();
    
    StaticConstrucEx2Outer<string>.StaticConstrucEx2Inner<string, Int16>.FooBar();
    StaticConstrucEx2Outer<string>.SCInner.FooBar();
    
    StaticConstrucEx2Outer<string>.StaticConstrucEx2Inner<string, UInt32>.FooBar();
    
    StaticConstrucEx2Outer<long>.StaticConstrucEx2Inner<string, UInt32>.FooBar();
