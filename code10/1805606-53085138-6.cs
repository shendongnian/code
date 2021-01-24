    public class CustomXmlReader : XmlTextReader
    {
        private readonly IList<String> _booleanFieldNames;
        private Boolean _parseBooleanString;
        public CustomXmlReader(IList<String> booleanFieldNames, TextReader reader) : base(reader)
        {
            this._booleanFieldNames = booleanFieldNames;
        }        
        public override XmlNodeType MoveToContent()
        {            
            XmlNodeType nodeType = base.MoveToContent();            
            this._parseBooleanString = ((XmlNodeType.Element == nodeType)
                && this._booleanFieldNames.Contains(this.Name)
                );            
            return nodeType;
        }        
        public override String ReadString()
        {
            String value = base.ReadString();                        
            if (this._parseBooleanString)
            {                
                if (value.Equals("TRUE", StringComparison.OrdinalIgnoreCase)
                    || value.Equals("T", StringComparison.OrdinalIgnoreCase)
                    || value.Equals("1", StringComparison.OrdinalIgnoreCase)
                    || value.Equals("YES", StringComparison.OrdinalIgnoreCase)
                    || value.Equals("Y", StringComparison.OrdinalIgnoreCase)
                    )
                { 
                    return "true";                        
                }
                    
                return "false";                
            }
            return value;
        }
    }
