    public class A 
    {
        // note that the method must not be private 
        // in order to be able to call it from intherited classes
        protected void someMethod(int i){
            //Do something
        }
    }
    
    public class B : A {
         // however, this class may be private of it needs to be
         void someMethod(int i, int j) 
         {
             this.someMethod(i); 
             // Do something more
         }
    }
