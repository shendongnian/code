    WebClient client = new WebClient();
    string getString = client.DownloadString("https://graph.facebook.com/zuck");
   
    JavaScriptSerializer serializer = new JavaScriptSerializer(); 
    dynamic item = serializer.Deserialize<object>(getString);
    string name = item["name"];
    //note: JavaScriptSerializer in this namespaces
    //System.Web.Script.Serialization.JavaScriptSerializer 
