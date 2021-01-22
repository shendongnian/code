    public class SomeClass: IClonable
     {
         // Some Code
    
         //Implementing interface method
         Public object Clone()
          {
            SomeClass ret = new SomeClass();
            // copy date from this instance to ret
            return ret;
          }
     }
