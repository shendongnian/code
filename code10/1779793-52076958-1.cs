    using Newtonsoft.Json;
    using System.Net;
    using System.IO;
    
    namespace MyNamespace
    {
    
        class Program
        {
            static void Main(string[] args)
            {
    
                //your input list
                List<string> animals = new List<string> { "Dog", "Cat", "Mouse" };
                var json = JsonConvert.SerializeObject(animals);
                //call your web API by passing this JSON along with your token
                CallWebService(json);
    	    }
            private static void CallWebService(string requestPayload)
            {
                string url = "your webservice URL";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = requestPayload.Length;
                StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
                requestWriter.Write(requestPayload);
                requestWriter.Close();
    
                try
                {
                    WebResponse webResponse = request.GetResponse();
                    Stream webStream = webResponse.GetResponseStream();
                    StreamReader responseReader = new StreamReader(webStream);
                    string response = responseReader.ReadToEnd();
                    Console.Out.WriteLine(response);
                    responseReader.Close();
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine("-----------------");
                    Console.Out.WriteLine(e.Message);
                }
    
            }
         }
    } 
 
