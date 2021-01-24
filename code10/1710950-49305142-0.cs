     public class B
     {
         private Lazy<A> _a;
 
         public A GetA 
         { 
             get { return _a.Value; } 
         }
         public B(Lazy<A> forLater)
         {
             _a = forLater;
         }
     }
