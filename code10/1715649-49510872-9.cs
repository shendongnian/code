    public class A 
    {
        // again, note that the method must not be private 
        // in order to be able to call it from intherited classes
        protected virtual void someMethod(int i){
            //Do something
        }
    }
    
    public class B : A {
         protected override void someMethod(int i) 
         {
             this.someMethod(i); 
             // Do something more
         }
    }
