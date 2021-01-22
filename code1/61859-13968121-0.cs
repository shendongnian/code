    void UpdateAppConfig(string param)
    {
       var doc = new XmlDocument();
       doc.Load("YourExeName.exe.config");
       XmlNodeList endpoints = doc.GetElementsByTagName("endpoint");
       foreach (XmlNode item in endpoints)
       {
           var adressAttribute = item.Attributes["address"];
           if (!ReferenceEquals(null, adressAttribute))
           {
               adressAttribute.Value = string.Format("http://mydomain/{0}", param);
           }
       }
       doc.Save("YourExeName.exe.config");
    }
