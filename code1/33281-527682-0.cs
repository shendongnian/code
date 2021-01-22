    public string LoadConfig()
    {
        string configPath = Server.MapPath(this.Context.Request.FilePath + ".xml");
        XmlReader reader = XmlReader.Create(configPath);
        // Will read Service1.asmx.xml, Service2.asmx.xml and so on
    }
    enter code here
