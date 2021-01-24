	[XmlRoot("Animals")]
	public class AnimalsHelper
	{
		[XmlElement("Cat", typeof(cat))]
		[XmlElement("Fish", typeof(fish))]
		public List<animals> Animals { get; set; } = new List<animals>();
	}
    static void Main(string[] args)
    {
    
        using (var xmlWriter = XmlWriter.Create("a.xml", new XmlWriterSettings { Indent = true }))
        {
            var animalsHelper= new AnimalsHelper();
            animalsHelper.Animals.Add(new cat { size = "10", furColor = "red" });
            animalsHelper.Animals.Add(new fish { size = "20", scaleColor = "blue" });
    
            new XmlSerializer(animalsHelper.GetType(),new[] { typeof(cat), typeof(fish) }).Serialize(xmlWriter, animalsHelper);
        }
		using (var xmlReader = XmlReader.Create("a.xml", new XmlReaderSettings { IgnoreWhitespace = true }))
		{
			var obj = (AnimalsHelper)new XmlSerializer(animalsHelper.GetType(), new[] { typeof(cat), typeof(fish) }).Deserialize(xmlReader);
		}
    }
