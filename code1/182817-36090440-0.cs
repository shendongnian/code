    try
    {
       HttpWebRequest request = (HttpWebRequest)WebRequest.Create("www.bing.com");
       request.Proxy = new WebProxy();
       request.Method = "POST";            
       request.AllowAutoRedirect = false;
       HttpWebResponse response = (HttpWebResponse)request.GetResponse();               
       if (response.StatusCode == HttpStatusCode.OK)
       {
          //some code here
       }
    }
    catch (exception e)
    {
       //Some other code here
    }
