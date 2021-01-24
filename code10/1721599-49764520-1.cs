    public class ERP_Company
    {
        [Key]
        public int CompanyID { get; set; }
        public string Name { get; set; }
        public ICollection<Contact> Contacts { set; get; }
    }
