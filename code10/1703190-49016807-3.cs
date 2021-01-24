    public partial class People
    {
        public People()
        {
            Address = new HashSet<Address>();
        }
        public int Id { get; set; }
        public int Name { get; set; }
        public virtual ICollection<Address> Address { get; set; }
    }
    public partial class Address
    {
        public int Id { get; set; }
        public string State { get; set; }
        public int PeopleId { get; set; }
        public People People { get; set; }
    }
