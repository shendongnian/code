    public class MySerilizedObject
    {
        [XmlIgnore]
        public bool BadBoolField { get; set; }
        [XmlElement("BadBoolField")]
        public string BadBoolFieldSerialize
        {
            get { return this.BadBoolField ? "True" : "False"; }
            set
            {
                if(value.Equals("True"))
                    this.BadBoolField = true;
                else if(value.Equals("False"))
                    this.BadBoolField = false;
                else
                    this.BadBoolField = XmlConvert.ToBoolean(value);
            }
        }
    }
