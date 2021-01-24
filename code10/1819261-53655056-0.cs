    public class listing
    {    
    
        public listing() // Create a costructor
        {
            // Initialize your List
            listingrooms = new List<listingrooms>();
        }
        public string title { get; set; }
        public int id { get; set; }
    
        public virtual ICollection<listingrooms> listingrooms { get; set; }
    }
