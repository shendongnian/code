    class MyThing : IDisposable
    {
        public bool ErrorOccurred() { get; set; }
    
        public void Dispose()
        {
            if (ErrorOccurred) {
                RollBack();
            } else {
                Commit();
            }
        }
    }
