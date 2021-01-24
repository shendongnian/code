    public class SomeClass : IDisposable
    {
         //pretend we implement a singleton pattern here
         //pretend we implement IDisposable here
        ~SomeClass()
        {
            Dispose(); 
        }
    }
