    public class FooCalculator<T>
    {
         private bool _isInitialized;
         private string _file;
         public FooCalculator(string file)
         {
             _file = file;
         }
         private EnsureInitialized()
         {
             if (_isInitialized) return;
             // Parse XML.
             // Fill some HashSets.
             _isInitialized = true;
         }
         public IEnumerable<T> Result
         {
             get {
                 EnsureInitialized();
                 ...
                 yield return ...;
                 ...
             }
         }
    }
