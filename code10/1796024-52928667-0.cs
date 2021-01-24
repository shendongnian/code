    public partial class Pages
    {
        public Pages()
        {
            Elements = new HashSet<Elements>();
        }
    
        public string Id { get; set; }
        public long Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? PageFlowId { get; set; }
        public bool NamedPage { get; set; }
        public bool? IsFirst { get; set; }
        public bool? IsLast { get; set; }
        public long? SurveyQuarter { get; set; }
        public long? SurveySyear { get; set; }
    
        public virtual PagesFlows PageFlow { get; set; }
        public virtual Surveys Survey { get; set; }
        public virtual ICollection<Elements> Elements { get; set; }
    } 
