    class Program
    {
        static void Main(string[] args)
        {
            string employeedata = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><tag><name>test</bar></nmae>";//demo xml data
            using (TextReader sr = new StringReader(employeedata))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Employee));//pass type name in XmlSerializer constructor here
                Employee response = (Employee)serializer.Deserialize(sr);
                Console.WriteLine(response.name);
            }
           
        }
    }
    [System.Xml.Serialization.XmlRoot("tag")]
    public class Employee
    {
        public string name { get; set; }
    }
