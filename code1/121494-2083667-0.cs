    public class BaseObj {
        BaseObj() {}
        protected override void Finalize() {
            // Perform resource cleanup code here... 
            // Example: Close file/Close network connection
            Console.WriteLine("In Finalize."); 
        }
    }
