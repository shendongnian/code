    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    
    namespace ClassLibrary1
    {
        public class MyHttpWebRequest : WebRequest
        {
            private WebRequest request;
    
            public MyHttpWebRequest(string uri)
            {
                request = HttpWebRequest.Create(uri);
            }
    
            public override WebResponse GetResponse()
            {
                // do your extras, or just delegate to get the original code, as long
                // as you still keep to expected behavior etc.
                return request.GetResponse();
            }
    
        }
    }
