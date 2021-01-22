    public ActionResult YourAction()
    {
        string postData = string.Empty;
        using (StreamReader sr = new StreamReader(Request.InputStream))
        {
            postData = sr.ReadToEnd();
        }    
    
        //Load post data into JObject (Newtonsoft.Json)
        JObject o = JObject.Parse(postData);
    
        //Extract each key/val 
        string val1 = (string)o["Key1"];
    
        //Do whatever....
    }
