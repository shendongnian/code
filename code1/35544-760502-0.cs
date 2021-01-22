     public class LazyFoo{
          private string bar;
          public string Bar{
             get{
                 // lazy load and return
             }
             set {
                 // set
             }
          }
        }
    
        public class Foo : LazyFoo{
          // only access the public properties here
        }
