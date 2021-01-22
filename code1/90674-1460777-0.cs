	using System;
	using System.IO;
	using System.Xml.Serialization;
	public static class Test
	{
		public static void Main(string[] args)
		{
			var fs = new FileStream("fruits.xml", FileMode.Open);
			var x = new XmlSerializer(typeof(Fruits));
			var fruits = (Fruits) x.Deserialize(fs);
			Console.WriteLine("{0} count: {1}", fruits.GetType().Name, fruits.fruits.Length);
			foreach(var fruit in fruits.fruits)
				Console.WriteLine("id: {0}, name: {1}", fruit.id, fruit.name);
		}
    }
    
    [XmlRoot("fruits")]
    public class Fruits
    {
    	[XmlElement(ElementName="fruit")]
    	public Fruit[] fruits;
    }
    
    public class Fruit
    {
    	public string name;
    	public int id;
    }
