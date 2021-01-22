    // Listing class/container/table
    public class Listing
    {
        public string ListingID {get;set;}
        public Int32? MakeID {get;set;}
    }
    // Make class/container/table
    public class Make
    {
        public Int32 MakeID {get;set;}
        public string Description {get;set;}
    }
    public class Main
    {
        public static void LinqMain()
        {
            // Populate the listing table with data
            List<Listing> listings = new List<Listing>()
            {
                new Listing() { ListingID = "Test 1", MakeID = 1 },
                new Listing() { ListingID = "Test 2", MakeID = 1 },
                new Listing() { ListingID = "No Make", MakeID = null },
                new Listing() { ListingID = "Test 3", MakeID = 3 },
                new Listing() { ListingID = "Another Makeless", MakeID = null }
            };
            // Populate the makes table with data
            List<Make> makes = new List<Make>()
            {
                new Make() { MakeID = 1, Description = "Make 1"},
                new Make() { MakeID = 2, Description = "Make 2"},
                new Make() { MakeID = 3, Description = "Make 3"},
                new Make() { MakeID = 4, Description = "Make 4"}
            };
            // Return the left join on Make Id
            var result = from l in listings
                         // These two lines are the left join. 
                         join leftm in makes on l.MakeID equals leftm.MakeID into leftm
                         from m in leftm.DefaultIfEmpty()
                         // To ensure the select does not get bogged down with too much logic use the let syntax
                         let description = m == null ? "NA" : m.Description
                         select new { l.ListingID, l.MakeID, description };
        }
