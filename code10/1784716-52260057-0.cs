    public class Address
    {
        [Column("Address")]
        public string Addr { get; set; }
        public string City { get; set; }
        public virtual Person Person { get; set; }
        [Key]
        public int PID { get; set; }
    }
