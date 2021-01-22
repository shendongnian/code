    public class Base64String: IXmlSerializable
    {
        private string value;
        public Base64String() { } 
        public Base64String(string value)
        {
            this.value = value;
        }
        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }
        public static implicit operator string(Base64String x)
        {
            return x.ToString();
        }
        public static implicit operator Base64String(string x)
        {
            return new Base64String(x);
        }
        public override string ToString()
        {
            return value;
        }
        #region IXmlSerializable Members
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            MemoryStream ms = null;
            byte[] buffer = new byte[256];
            int bytesRead;
            
            while ((bytesRead = reader.ReadElementContentAsBase64(buffer, 0, buffer.Length)) > 0)
            {
                if (ms == null) 
                    ms = new MemoryStream(bytesRead);
                
                ms.Write(buffer, 0, bytesRead);
            }
            
            if (ms != null)
                value = System.Text.UnicodeEncoding.Unicode.GetString(ms.ToArray());
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            if (!string.IsNullOrEmpty(value))
            {
                byte[] rawData = Encoding.Unicode.GetBytes(value);
                writer.WriteBase64(rawData, 0, rawData.Length); 
            }
        }
        static public string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes
                  = System.Text.UnicodeEncoding.Unicode.GetBytes(toEncode);
            string returnValue
                  = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }
        static public string DecodeFrom64(string encodedData)
        {
            byte[] encodedDataAsBytes
                = System.Convert.FromBase64String(encodedData);
            string returnValue =
               System.Text.UnicodeEncoding.Unicode.GetString(encodedDataAsBytes);
            return returnValue;
        }
        #endregion
    }
