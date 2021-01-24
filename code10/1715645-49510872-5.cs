    public class A {
        protected void someMethod(int i){
            //Do something
        }
    }
    
    public class B : A {
         void someMethod(int i, int j) 
         {
             this.someMethod(i); 
             // Do something more
         }
    }
