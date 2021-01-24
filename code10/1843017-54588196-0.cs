    public class Merchant
    {
        // note added Id property
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
        [JsonProperty(PropertyName = "venues")]
        public List<Venue> venues { get; set; }
    }
    public class Venue
    {
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
        [JsonProperty(PropertyName = "tills")]
        public List<Till> tills { get; set; }
    }
 
    public class Till
    {
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
    }
    public void MerchantsTest()
    {
        using (var store = GetDocumentStore())
        {
            using (var session = store.OpenSession())
            {
                session.Store(new Merchant { Id = "merchant-1", name = "merchant1", venues = new List<Venue> { new Venue { name = "venue-1A", tills = new List<Till> { new Till { name = "till-1A-first" } } } } });
                session.Store(new Merchant { Id = "merchant-2", name = "merchant2", venues = new List<Venue> { new Venue { name = "venue-2A", tills = new List<Till> { new Till { name = "till-2A-first" } } } } });
                session.SaveChanges();
            }
            using (var session = store.OpenSession())
            {
                // you can load all merchants
                var merchants = session.Query<Merchant>(null, "Merchants").ToList();
                // or load specific merchant by ID
                var merchant2 = session.Load<Merchant>("merchant-1");
                // add a venue to a loaded merchant (not using patch but simply adding the object)
                merchant2.venues.Add(new Venue { name = "venue-2B", tills = new List<Till> { new Till { name = "till-2B-first" } } });
                session.SaveChanges();
            }
        }
    }
