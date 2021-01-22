    public class MyFault
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
    public static XmlDocument SerializeFault()
    {
        var fault = new MyFault
                        {
                            ErrorCode = 1,
                            ErrorMessage = "This is an error"
                        };
        var faultDocument = new XmlDocument();
        var nav = faultDocument.CreateNavigator();
        using (var writer = nav.AppendChild())
        {
            var ser = new XmlSerializer(fault.GetType());
            ser.Serialize(writer, fault);
        }
        var detailDocument = new XmlDocument();
        var detailElement = detailDocument.CreateElement(
            "exc", 
            SoapException.DetailElementName.Name,
            SoapException.DetailElementName.Namespace);
        detailDocument.AppendChild(detailElement);
        detailElement.AppendChild(
            detailDocument.ImportNode(
                faultDocument.DocumentElement, true));
        return detailDocument;
    }
