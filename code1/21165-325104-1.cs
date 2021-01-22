    [DataContract]
    class Foo
    {
        [DataMember(Name = "objects")]
        public Bar Bar { get; set; }
    }
    
    [DataContract]
    class Bar
    {
        public Bar() {
            Categories = new List<Category>();
            Present = new List<Present>();
        }
        [DataMember(Name = "categories")]
        public List<Category> Categories { get; private set; }
        [DataMember(Name = "present")]
        public List<Present> Present { get; private set; }
    }
    [DataContract]
    class Category
    {
        [DataMember(Name = "name")]
        public string Name {get;set;}
        [DataMember(Name = "imageID")]
        public int ImageID {get;set;}
        [DataMember(Name = "isActive")]
        public int IsActive {get;set;}
        [DataMember(Name = "displayOrder")]
        public int DisplayOrder {get;set;}
        [DataMember(Name = "dateUpdated")]
        public string DateUpdated {get;set;}
    }
    [DataContract]
    class Present
    {
        [DataMember(Name = "presentID")]
        public int PresentID {get;set;}
        [DataMember(Name = "name")]
        public string Name {get;set;}
        [DataMember(Name = "categoryID")]
        public int CategoryID {get;set;}
        [DataMember(Name = "imageID")]
        public int ImageID {get;set;}    
        [DataMember(Name = "dateUpdated")]
        public string DateUpdated {get;set;}
        [DataMember(Name = "isActive")]
        public int IsActive {get;set;}
        [DataMember(Name = "isAnimated")]
        public int? IsAnimated {get;set;}
        [DataMember(Name = "isInteractive")]
        public int? IsInteractive {get;set;}
        [DataMember(Name = "isAdaptive")]
        public int? IsAdaptive {get;set;}
        [DataMember(Name = "webLinkURL")]
        public string WebLinkUrl {get;set;}
    }
