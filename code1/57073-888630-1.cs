    public class BusinessList
    {   
        public List<Business> TheList;
        public BusinessList()
        {    
            TheList = new List<Business>();
            TheList.Add(new Business("1", "Business Name 1"));
            TheList.Add(new Business("2", "Business Name 2"));   
        }
    }
