    public class Location
    {
        [Column("LocationID")]
        public long LocationID { get; set; }
        [ForeignKey("ID")]
        public long? PhotoID { get; set; }
        public virtual Photo Photo{ get; set; }
    }
