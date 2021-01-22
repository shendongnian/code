         var doc = new XmlDocument();
         doc.Load(FileTransferConstants.Constants.SERVICE_ENDPOINTS_XMLPATH);
         XmlNodeList endPoints = doc.SelectNodes("/Services/Service/Endpoints");  
         foreach (XmlNode endPoint in endPoints)
         {
            foreach (XmlNode child in endPoint)
            {
                if (child.Attributes["name"].Value.Equals("ep1"))
                {
                    var adressAttribute = child.Attributes["address"];
                    if (!ReferenceEquals(null, adressAttribute))
                    {
                        address = adressAttribute.Value;
                    }
               }
           }
        }  
