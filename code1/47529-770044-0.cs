    public partial class _Default : Page
    {
        [WebMethod]
        public static MethodResult SaveData(string nodeId, string value,
                                            string elementId)
        {
            return new MethodResult
                   { ElementId = elementId, Result = new Random().Next(42) };
        }
    }
    public class MethodResult
    {
        public string ElementId { get; set; }
        public int Result { get; set; }
    }
