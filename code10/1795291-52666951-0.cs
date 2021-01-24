    public partial class TwoKeysTable
    {
        public decimal Key1 { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Key2 { get; set; }
        public string Test { get; set; }
    }
