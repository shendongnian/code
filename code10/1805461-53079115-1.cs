    class Example
    {
       [InitMethod]
       private void Init()
       {
          Console.WriteLine("Initializing...");
       }
       [InitMethod]
       private void InitMore()
       {
          Console.WriteLine("More initializing...");
       }
       [RunMethod]
       private void Run()
       {
          Console.WriteLine("Running...");
       }
       [CleanupMethod]
       private void Cleanup()
       {
          Console.WriteLine("Cleaning up...");
       }
    }
