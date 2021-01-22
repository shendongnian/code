    public class Foo : IDisposable
    {
        public void Dispose() 
        {
            // NOP
        }
   
        ~Foo()
        {
            Dispose();
        } 
    }
