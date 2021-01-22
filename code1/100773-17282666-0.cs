    public class A {
      public void foo<T>( ref T x ) where T : X {  
        x._x = 1;  
      }  
    }  
    
    public class B : A {  
      public void bar( ref Y y ) {  
        foo<Y>( ref y ); // works now
        y._y = 2;
      }  
    }
