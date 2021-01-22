    XmlDocument document = new XmlDocument();
    document.Load("Web.Config"); 
    
    XmlNode pagesenableSessionState = document.SelectSingleNode("//Settings[@Name = 'pages']/Setting[@key='enableSessionState']");
    
    if(pagesenableSessionState .Attributes["value"].Value =="true)
    {
    //Sessions are enabled
    }
    else
    {
    //Sessions are not enabled
    }
