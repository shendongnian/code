    public static String[] readXML(String filename)
    {
        using(XmlReader xmlReader = XmlReader.Create(@filename))
        {
            List<String> names = new List<string>();
            while(xmlReader.Read())
            {
                //Keep reading  
                if(xmlReader.Name.Equals("Keyword") && (xmlReader.NodeType == XmlNodeType.Element))
                {
                    // get attribute from the Xml element here  
                    string keywords = xmlReader.GetAttribute("name");
                    names.Add(keywords);
                }
            }
            String[] keywordsArray = names.ToArray();
            return keywordsArray;
        }
    }
