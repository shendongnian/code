    /// <summary>
    /// Changes the xml in sourceFileName and writes the changed xml to destFileName
    /// </summary>
    public static void ProcessNames(string sourceFileName, string destFileName)
    {
        XmlDocument xmlDoc = new XmlDocument();
        XmlTextWriter xtw = null;
        xmlDoc.Load(sourceFileName);
    
        try
        {
            // Parse through all the item nodes and process them
            XmlNodeList itemList = xmlDoc.SelectNodes("//root/item");
    
            if (itemList.Count > 0)
            {
                foreach (XmlNode item in itemList)
                {
                    // Change the name attribute, if it exists
                    if (item.Attributes["name"] != null)
                    {
                        string newItemName = item.Attributes["name"].Value + "Joel";
                        item.Attributes["name"].Value = newItemName;
                    }
    
                    // Parse through all the foo nodes and process them
                    XmlNodeList fooList = item.SelectNodes("foo");
    
                    if (fooList.Count > 0)
                    {
                        foreach (XmlNode foo in fooList)
                        { 
                            // Change the name attribute, if it exists
                            if (foo.Attributes["name"] != null)
                            {
                                string newFooName = foo.Attributes["name"].Value + "Joel";
                                foo.Attributes["name"].Value = newFooName;
                            }
                        }
                    }
    
                }
    
                xtw = new XmlTextWriter(destFileName, Encoding.UTF8);
                xmlDoc.WriteContentTo(xtw);
            }
    
        }
        finally
        {
            xtw.Close();
        }
    }
