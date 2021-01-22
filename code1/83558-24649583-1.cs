    internal sealed class Bucket : IBucket
    {
        private Collection<Nail> nails;
    
        Collection<INail> IBucket<Nail>.Nails
        {
            get
            {
                List<INail> temp = new List<INail>();
                foreach (Nail nail in nails)
                    temp.Add(nail);
              
                return new Collection<INail>(temp);  
            }
        }
    
        public Bucket()
        {
            this.nails = new Collection<Nail>();
        }
    }
