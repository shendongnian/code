        [Column(TypeName = "datetime2")]
        [XmlAttribute]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Date Modified")]
        [DateRange(Min = "1900-01-01", Max = "2999-12-31")]
        public DateTime DateModified {
            get { return dateModified; }
            set { dateModified = value; } 
        }
        private DateTime dateModified = DateTime.Now.ToUniversalTime();
