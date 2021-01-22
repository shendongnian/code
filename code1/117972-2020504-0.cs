      XDocument xmlDoc = XDocument.Load(fileName);
    
        XElement page = xmlDoc.Descendants("MySettings").FirstOrDefault();
               
       string AttachmentsPath  =  page.Descendants("AttachmentsPath").First().Value;
    
       string PendingAttachmentsPath=  page.Descendants("PendingAttachmentsPath").First().Value;
