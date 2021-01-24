     XmlSerializer xsSubmit = new XmlSerializer(typeof(List<YourClass>));
     var subReq = AllMyData.ToList();
     var xml = "";
    
     using(var sww = new StringWriter())
     {
         using(XmlWriter writer = XmlWriter.Create(sww))
         {
             xsSubmit.Serialize(writer, subReq);
             xml = sww.ToString(); // Your XML
         }
     }
