    public class BusinessItem
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
    public class BusinessItemsDAO
    {
    ...
        public List<BusinessItem>   List()
        {
            // fake... should retrieve from db
            var list = new List<BusinessItem>();
            // returs the list
            return list;
        }
    ...
    }
