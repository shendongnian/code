       try
       {
            WebClient client = new WebClient { Proxy = null };
            string link = client.DownloadString("https://snyicalistic123.000webhostapp.com/aqua.json");
            Dictionary<string, user> jsa = JsonConvert.DeserializeObject<Dictionary<string, user>>(link);
            string username = jsa[key].username;
            return username;
       }
       catch(Exception e)
       {
           return e.Message;
       }
