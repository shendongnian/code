    public IHttpActionResult Get()
    {
        if (!File.Exists(@"D:\myfile.xml"))
            return NotFound();
        //Read XML
        XDocument xDoc = XDocument.Load(@"D:\myfile.xml");
        string jsonStr = JsonConvert.SerializeXNode(xDoc);
        JObject json = JObject.Parse(jsonStr);
        return Ok(json);
    }
