    namespace CompanyName.Net
    {
        [Guid("F7075E8D-A6BD-4590-A3B5-7728C94E372F")]
        [ClassInterface(ClassInterfaceType.AutoDual)]
        [ProgId("CompanyName.Net.Webrequest")]
        public class WebRequest
        {
            public string Result { get; private set; }
            public string Url { get; set; }
            public string StatusDescription { get; private set; }
            public HttpStatusCode StatusCode { get; private set; }
            public WebRequest()
            {
            }
    
            public string GetResponse(string url)
            {
                System.Net.WebRequest webreq = System.Net.WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse) webreq.GetResponse();
                // Store the status.
                StatusDescription = response.StatusDescription;
                StatusCode = response.StatusCode;
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                Result = reader.ReadToEnd();
                // Cleanup the streams and the response.
                reader.Close();
                dataStream.Close();
                response.Close();
                //return the response
                return Result;
            }
        }
    }
