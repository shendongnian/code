    using System.Net;
    using System.Net.Http;  // in LINQPad, also add a reference to System.Net.Http.dll
    
    WebRequest req = HttpWebRequest.Create("http://google.com");
    req.Method = "GET";
    
    string source;
    using (StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream()))
    {
    	source = reader.ReadToEnd();
    }
    
    Console.WriteLine(source);
