    public class Business
    {
        //Business class methods/properties/fields
        
        static List<Business> GetList()
        {
            List<Business> businesses = new List<Business>();
            businesses.Add(new Business("1", "Business Name 1"));
            businesses.Add(new Business("2", "Business Name 2"));
            return businesses;
        }
    }
