    static void Main(string[] args) {
       try {
          DisposableType d = new DisposableType();
          d.Dispose();
          d = null;
          GC.Collect();
          GC.WaitForPendingFinalizers();
       } catch {
          Console.WriteLine("catch");
       } finally {
          Console.WriteLine("finally");
       }
    }
    
    public class DisposableType : IDisposable {
       public void Dispose() {
       }
    
       ~DisposableType() {
          throw new NotImplementedException();
       }
    }
