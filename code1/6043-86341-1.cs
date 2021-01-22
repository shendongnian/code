    public class MyXmlDocument: XmlDocument
    {
      bool TryParseXml(string xml){
        try{
          ParseXml(xml);
          return true;
        }catch(XmlException e){
          return false;
        }
     }
