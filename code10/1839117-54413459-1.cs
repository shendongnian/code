    class Program
    {
        static void Main(string[] args)
        {
            var serializer = new XmlSerializer(typeof(Activity));
            Activity activity;
            using (var stream = File.OpenText("Test.xml"))
            {
                activity = (Activity) serializer.Deserialize(stream);
            }
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, "http://schemas.microsoft.com/netfx/2009/xaml/activities");
            ns.Add("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            ns.Add("sco", "clr-namespace:System.Collections.ObjectModel;assembly=mscorlib");
            ns.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
            using (var stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, activity, ns);
                Console.WriteLine(stringWriter.ToString());
            }
        }
    }
