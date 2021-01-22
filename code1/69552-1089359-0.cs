    public bool IsOn()
    {
        HttpWebRequest request = (HttpWebRequest) WebRequest.Create
            ("http://" + this.routerIp + "/top_conn.xml");
        request.Timeout = 500;
        using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
        using (XmlReader reader = XmlReader.Create(response.GetResponseStream()))
        {      
            while (reader.Read())
            {
                string value = reader.Value;
                if (value.Trim() != "")
                {
                    return value.Substring(value.IndexOf("=") + 1, 1) != "0";
                }
            }
        }
        return false;    
    }
