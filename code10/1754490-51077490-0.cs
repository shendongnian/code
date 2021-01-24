    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load("xml.xml");
            XElement response = doc.Elements().FirstOrDefault();
            List<XElement> xmlMemberSummaries = response.Elements().ToList();
            List<MemberSummary> memberSummaries = xmlMemberSummaries.Select(x => Deserialize<MemberSummary>(x.ToString())).ToList();
        }
    
        public static string Serialize<T>(T dataToSerialize)
        {
            try
            {
                var stringwriter = new System.IO.StringWriter();
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stringwriter, dataToSerialize);
                return stringwriter.ToString();
            }
            catch
            {
                throw;
            }
        }
    
        public static T Deserialize<T>(string xmlText)
        {
            try
            {
                var stringReader = new System.IO.StringReader(xmlText);
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
            catch
            {
                throw;
            }
        }
    }
    
    
    public class MemberSummary
    {
        public int Age { get; set; }
        public string DateOfBirth { get; set; }
        public string EmailAddress { get; set; }
        public MobilePhone MobilePhone { get; set; }
        public WorkPhone WorkPhone { get; set; }
        public HomePhone HomePhone { get; set; }
    }
    
    public interface Phone
    {
        string CountryCode { get; set; }
        string Number { get; set; }
    }
    
    public class MobilePhone : Phone
    {
        public string CountryCode { get; set; }
        public string Number { get; set; }
    }
    
    public class WorkPhone : Phone
    {
        public string CountryCode { get; set; }
        public string Number { get; set; }
    }
    
    public class HomePhone : Phone
    {
        public string CountryCode { get; set; }
        public string Number { get; set; }
    }
