    using System.Threading.Tasks;
    
    class Example
    {
       ...
       private void ExampleFunc()
       {
           // Whitout using
           System.Threading.Tasks.Task.Wait(1000);
    
           // OR
           
           // With using
           Task.Wait(1000);
       }
       ...
    }
