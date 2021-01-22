    public class EncryptMessageAttribute : SoapExtensionAttribute
    {
        private string strKey="null";
    
        public string Key
        {
            get { return strKey; }
            set { strKey = value; }
        }
    }
    [WebMethod]
    [EncryptMessageAttribute(Key = "null")]
    public string test2()
    {
        return "ok";
    }
