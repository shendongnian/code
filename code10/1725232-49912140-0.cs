    public class SomethingDisposable : IDisposable
    {
        public void Dispose()
        {
            //Dispose of some unmanaged resources or something.
            GC.SuppressFinalize(this); //We can safely skip the Destructor method (Finaliser)
        }
        ~SomethingDisposable() => Dispose(); //Just incase the object is garbage collected and never properly disposed.
    }
