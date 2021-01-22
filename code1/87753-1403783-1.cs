    public class Customer
    {
        private readonly CorporateSite site;
        public Customer()
        {
            this.site = new CorporateSite(this.GetSites);
        }
        public CorporateSite CorporateSite
        {
            get { return this.site; }
        }
        private IList<Site> GetSites()
        {
            // Put real implementation here
            return new List<Site>();
        }
    }
