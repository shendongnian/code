    using (WebResponse response = req.GetResponse())
    using (StreamReader reader = new StreamReader(response.GetResponseStream())
    {
        while ((line = reader.ReadLine()) != null) {
            site += line;
        }
    }
