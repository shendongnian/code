     public class clsSAPSettings: IDisposable {
       private MyTemp mtbTemp;
       ... 
       protected virtual void Dispose(bool disposing) {
         if (disposing) { 
            mtbTemp?.Close();
            GC.SuppressFinalize(this); 
         }
       }  
       public void Dispose() {
         Dispose(true);
       }
       //TODO: do you really want finalizer?
       ~clsSAPSettings() {
         Dispose(false);
       } 
     }
     
