    internal sealed class Bucket : IBucket
    {
        private Nail[] nails;
        INail[] IBucket.Nails
        {
            get { return this.nails; }
        }
        public Bucket()
        {
            this.nails = new Nail[100];
        }
    }
