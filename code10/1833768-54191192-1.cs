    using System.Threading.Tasks;
    
    class Example
    {
       ...
       private void ExampleFunc()
       {
           // Whitout using
           System.Threading.Tasks.Task.Delay(5000).Wait();
    
           // OR
           
           // With using
           Task.Delay(5000).Wait();
       }
       ...
    }
