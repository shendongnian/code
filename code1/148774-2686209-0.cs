    public class MyRepository : IDisposable
    {
        ...  // everything except the dtor
        public void Dispose()
        {
            if (dc != null)
            {
                dc.Dispose();
            } 
        }
    }
