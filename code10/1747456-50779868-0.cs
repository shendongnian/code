    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = false)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Animals
    {
        private AnimalsCat[] catField;
        private AnimalsFish[] fishField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("cat")]
        public AnimalsCat[] cat
        {
            get
            {
                return this.catField;
            }
            set
            {
                this.catField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("fish")]
        public AnimalsFish[] fish
        {
            get
            {
                return this.fishField;
            }
            set
            {
                this.fishField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = false)]
    public partial class AnimalsCat
    {
        private byte sizeField;
        private string furColorField;
        /// <remarks/>
        public byte size
        {
            get
            {
                return this.sizeField;
            }
            set
            {
                this.sizeField = value;
            }
        }
        /// <remarks/>
        public string furColor
        {
            get
            {
                return this.furColorField;
            }
            set
            {
                this.furColorField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = false)]
    public partial class AnimalsFish
    {
        private byte sizeField;
        private string scaleColorField;
        /// <remarks/>
        public byte size
        {
            get
            {
                return this.sizeField;
            }
            set
            {
                this.sizeField = value;
            }
        }
        /// <remarks/>
        public string scaleColor
        {
            get
            {
                return this.scaleColorField;
            }
            set
            {
                this.scaleColorField = value;
            }
        }
    }
