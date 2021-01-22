    public class MyClass
    {
        string _data;
    
        [XmlText]
        public string Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }
