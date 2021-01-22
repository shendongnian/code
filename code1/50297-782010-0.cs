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
        var detailDocument = new XmlDocument();
        var nav = detailDocument.CreateNavigator();
        if (nav != null)
            using (var writer = nav.AppendChild())
            {
                var ser = new XmlSerializer(fault.GetType());
                ser.Serialize(writer, fault);
            }
        return detailDocument;
    }
