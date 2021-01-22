    using System.Net;
    using System.Collections.Specialized;  
    
    NameValueCollection values = new NameValueCollection();
    values.Add("TextBox1", "value1");
    values.Add("TextBox2", "value2");
    values.Add("TextBox3", "value3");
    string Url = urlvalue.ToLower();
    
    using (WebClient client = new WebClient())
    {
        client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
        byte[] result = client.UploadValues(Url, "POST", values);
        string ResultAuthTicket = Encoding.UTF8.GetString(result);
    }
