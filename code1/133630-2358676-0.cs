    public class TestThreading
     {
         // private System.Object lockThis = new System.Object();
    
         public void Function()
         {
    
             lock (this)
             {
                // Access thread-sensitive resources.
             }
         }
      }
