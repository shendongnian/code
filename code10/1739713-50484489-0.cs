    public class Values
    {
        public Values()
        {
             keyValues = new List<ContactsDeserialize>();
        }
        public string odata_context  {get; set; }
        public List<ContactsDeserialize> keyValues { get; set; }
    }
