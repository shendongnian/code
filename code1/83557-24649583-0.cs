    public interface IBucket<T> where T : INail
    {
        Collection<T> Nails
        {
            get;
        }
    }
    
    public interface INail
    {
    }
    
    internal sealed class Nail : INail
    {
    }
    
    internal sealed class Bucket : IBucket<Nail>
    {
        private Collection<Nail> nails;
    
        Collection<Nail> IBucket<Nail>.Nails
        {
            get
            {
                return nails; //works
            }
        }
    
        public Bucket()
        {
            this.nails = new Collection<Nail>();
        }
    }
