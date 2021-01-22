    System.Net.ServicePointManager.DefaultConnectionLimit = 200;
    System.Net.ServicePointManager.MaxServicePointIdleTime = 2000;
    System.Net.ServicePointManager.MaxServicePoints = 1000;
    System.Net.ServicePointManager.SetTcpKeepAlive(false, 0, 0);
    HttpWebRequest webRequest1 = (HttpWebRequest)WebRequest.Create("http://" + gatewayIP
     + "/xslt?");
    webRequest1.KeepAlive = false;
    webRequest1.Timeout = 2000;
    //Do other stuff here...
    //Close response stream
    Thread.Sleep(1000); //This delay seems to help. Obviously very specific to the server
    HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create("http://" + gatewayIP
     + "/xslt?");
    webRequest2.KeepAlive = false;
    webRequest2.Timeout = 2000;
    //Do other stuff here...
    //and so on...
