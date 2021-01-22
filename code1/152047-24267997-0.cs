    public class MyWebService
    {
        public SoapUnknownHeader[] unknownHeaders;
     
        [WebMethod]
        [SoapHeader("unknownHeaders")]
        public string MyWebMethod() 
        {
            foreach (SoapUnknownHeader header in unknownHeaders) 
            {
                // process headers
            }
            // handle request
        }
    }
