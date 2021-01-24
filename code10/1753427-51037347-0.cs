     public class Item: TableEntity
     {
        public Item(String PartitionKey, String RowKey, String Name, String Email=null, String Address=null)
        {
            this.RowKey = RowKey ;
            this.PartitionKey = PartitionKey;
            this.Name = Name;
            this.Email = Email;
            this.Address = Address;
        }
       
        public Item(){}
        public String Name { get; set; }
        public String Email { get; set; }
        public String Address { get; set; }
    }
