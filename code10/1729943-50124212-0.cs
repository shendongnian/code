    public class Response
    {
        [System.Xml.Serialization.XmlElementAttribute("Business", typeof(ResponseBusiness), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public object[] Items { get; set; }
    }
    public partial class ResponseBusiness
    {
        string NumberField;
        string NameField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Number
        {
            get
            {
                return this.NumberField;
            }
            set
            {
                this.NumberField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
