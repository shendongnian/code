    public partial class icqty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // primary key example
        public string ProductCode { get; set; }
        public Nullable<int> QuantityInStock { get; set; }
        public string LocationCode { get; set; }
        public int RecordRevision { get; set; }
        public string AirTableRec { get; set; }
    }
