    public class ExchangeCourseSource : IExchangeCourseSource
    {
        public ExchangeCourseSource(XmlDocument sourceDocument)
        {
            this.sourceDocument = sourceDocument;
        }
    
        public ExchangeCourse GetCourse(string currency)
        {
            // parse from XML (see your code)
        }
    
    }
    
    class ExchangeCourse
    {
        public string Currency { get; set; }
        public double ExchangeRate { get; set; }
        public double Difference { get; set; }
    }
