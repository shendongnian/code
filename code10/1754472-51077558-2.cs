    using (WebClient client = new WebClient())
    {
        var values = new Dictionary<string,object> { { "menu_parent",null } }; 
        var parameterJson = JsonConvert.SerializeObject(values);
        client.Headers.Add("Content-Type", "application/json"); 
        string URL = "http://192.168.20.152/test.php";
        byte[] response = client.UploadData(URL, Encoding.UTF8.GetBytes(parameterJson));
    
        string responseString = Encoding.Default.GetString(response);
    
        MessageBox.Show(responseString);
    }
