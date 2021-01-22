    public class Foo
    {
        [XmlIgnore]
        public DateTime Bar { get; set; }
    
        public string BarFormatted
        {
            get { return this.Bar.ToString("dd-MM-yyyy"); }
            set { this.Bar = DateTime.ParseExact(value, "dd-MM-yyyy", null); }
        }
    }
