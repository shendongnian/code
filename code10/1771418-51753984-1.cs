    public class City : BaseEntity<Int32>
    {        
        public string Name { get; set; }
        public Int32 CountryID { get; set; }
        public virtual Country Country { get; set; }
    }
