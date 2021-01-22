    public class MyObject
    {
        public MyObject()
        {
            BCSFilters = new List<BCSFilter>();
        }
    
        public IEnumerable<BCSFilter> BCSFilters { get; set; }
    }
