    public class BusinessHelper
    {   
        public static List<Business> ListBusinesses()
        {
    
            List<Business> businesses = new List<Business>();
            businesses.Add(new Business("1", "Business Name 1"));
            businesses.Add(new Business("2", "Business Name 2"));
    
            return businesses;
        }
    }
