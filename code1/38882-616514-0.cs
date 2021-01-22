    [TestMethod]
    public void TestMethod3()
    {
        var list = new []{new SitemapNode("1", DateTime.Now, 1), new SitemapNode("2", DateTime.Now.AddDays(1), 2)};
        var serializer = new XmlSerializer(typeof(SitemapNode));
        var st = new MemoryStream();
        using (var writer = XmlWriter.Create(st))
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "test");
            writer.WriteStartElement("test", "test");
            foreach (SitemapNode node in list)
            {
                serializer.Serialize(writer, node, ns);
            }
            writer.WriteEndElement();
        }
        st.Position = 0;
        TestContext.WriteLine(new StreamReader(st).ReadToEnd());
    }
    [XmlRoot(ElementName = "url", Namespace = "test")]
    public class SitemapNode
    {
        [XmlElement(ElementName = "loc")]
        public string Location { get; set; }
        [XmlElement(ElementName = "lastmod")]
        public DateTime LastModified { get; set; }
        [XmlElement(ElementName = "priority")]
        public decimal Priority { get; set; }
    
        public SitemapNode()
        {
            Location = String.Empty;
            LastModified = DateTime.Now;
            Priority = 0.5M;
        }
    
        public SitemapNode(string location, DateTime lastModified, decimal priority)
        {
            Location = location;
            LastModified = lastModified;
            Priority = priority;
        }
    }
