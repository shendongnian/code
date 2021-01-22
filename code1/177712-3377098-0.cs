    public class HoldsResources : IDisposable
    {
        public HoldsResources()
        {
            // Maybe grab some resources here
            throw new Exception("whoops");
        }
    }
    
    using (HoldsResources hr = new HoldsResources())
    {
    }
