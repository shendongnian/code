    using System.Net;
    //...
    using (WebClient client = new WebClient ()) 
    {
        client.QueryString.Add("p", "1500"); //add parameters
        string htmlCode = client.DownloadString("www.somesite.it");
        //...
    }
