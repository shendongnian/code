    [ActiveRecord(Table = "NewsMaster")]
    public class Article
    {
        [PrimaryKey(Generator = PrimaryKeyType.Identity)]
        public int NewsId { get; set; }
        [Property(Column = "NewsHeadline")]
        public string Headline { get; set; }
        [Property(Column = "EffectiveStartDate")]
        public DateTime StartDate { get; set; }
        [Property(Column = "EffectiveEndDate")]
        public DateTime EndDate { get; set; }
        [Property]
        public string NewsBlurb { get; set; }
    }
