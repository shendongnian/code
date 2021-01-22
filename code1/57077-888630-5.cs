    public class BusinessList
    {   
        public List<Business> TheList;
        public static BusinessList BusinessListWithTwoCompanies()
        {
            BusinessList instance = new BusinessList();
    
            businesses = new List<Business>();
            businesses.Add(new Business("1", "Business Name 1"));
            businesses.Add(new Business("2", "Business Name 2"));
    
            return instance;
        }
    }
