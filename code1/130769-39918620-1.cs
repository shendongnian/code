    #region Références
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    #endregion
    
    namespace XmlSerializationTests
    {
    	[TestClass]
    	public class XmlSerializableListTests
    	{
    		public class Person
    		{
    			public string FirstName { get; set; }
    			public string LastName { get; set; }
    			public int Birth { get; set; }
    		}
    
    		[XmlRoot("color")]
    		public class ColorDefinition
    		{
    			[XmlElement("name")] public string Name { get; set; }
    			[XmlElement("r")] public int Red { get; set; }
    			[XmlElement("g")] public int Green { get; set; }
    			[XmlElement("b")] public int Blue { get; set; }
    		}
    
    		public class Persons : XmlSerializableList<Person>
    		{
    		}
    
    		[XmlRoot("colors")]
    		public class ColorList : XmlSerializableList<ColorDefinition>
    		{
    		}
    
    		private T ReadXml<T>(string text) where T : class
    		{
    			XmlSerializer serializer = new XmlSerializer(typeof (T));
    			using (StringReader sr = new StringReader(text))
    			{
    				return serializer.Deserialize(sr) as T;
    			}
    		}
    
    		private string WriteXml<T>(T data) where T : class
    		{
    			XmlSerializer serializer = new XmlSerializer(typeof(T));
    			StringBuilder sb = new StringBuilder();
    			using (StringWriter sw = new StringWriter(sb))
    			{
    				serializer.Serialize(sw, data);
    				return sb.ToString();
    			}
    		}
    
    		[TestMethod]
    		public void ReadEmpty()
    		{
    			string xml = @"<?xml version=""1.0"" encoding=""utf-16""?>
    <XmlSerializableListOfInt32>
    </XmlSerializableListOfInt32>";
    			XmlSerializableList<int> lst = ReadXml<XmlSerializableList<int>>(xml);
    			Assert.AreEqual(0, lst.Count);
    		}
    
    		[TestMethod]
    		public void ReadEmpty2()
    		{
    			string xml = @"<?xml version=""1.0"" encoding=""utf-16""?>
    <XmlSerializableListOfInt32 />";
    			XmlSerializableList<int> lst = ReadXml<XmlSerializableList<int>>(xml);
    			Assert.AreEqual(0, lst.Count);
    		}
    
    		[TestMethod]
    		public void ReadSimpleItems()
    		{
    			string xml = @"<?xml version=""1.0"" encoding=""utf-16""?>
    <XmlSerializableListOfInt32>
      <int>0</int>
      <int>52</int>
      <int>79</int>
    </XmlSerializableListOfInt32>";
    			XmlSerializableList<int> lst = ReadXml<XmlSerializableList<int>>(xml);
    			Assert.AreEqual(3, lst.Count);
    			Assert.AreEqual(0, lst[0]);
    			Assert.AreEqual(52, lst[1]);
    			Assert.AreEqual(79, lst[2]);
    		}
    
    		[TestMethod]
    		public void ReadComplexItems()
    		{
    			string xml = @"<?xml version=""1.0"" encoding=""utf-16""?>
    <XmlSerializableListOfPerson>
      <Person>
        <FirstName>Linus</FirstName>
        <LastName>Torvalds</LastName>
        <Birth>1969</Birth>
      </Person>
      <Person>
        <FirstName>Bill</FirstName>
        <LastName>Gates</LastName>
        <Birth>1955</Birth>
      </Person>
      <Person>
        <FirstName>Steve</FirstName>
        <LastName>Jobs</LastName>
        <Birth>1955</Birth>
      </Person>
    </XmlSerializableListOfPerson>";
    			XmlSerializableList<Person> lst = ReadXml<XmlSerializableList<Person>>(xml);
    			Assert.AreEqual(3, lst.Count);
    			Assert.AreEqual("Linus", lst[0].FirstName);
    			Assert.AreEqual("Torvalds", lst[0].LastName);
    			Assert.AreEqual(1969, lst[0].Birth);
    			Assert.AreEqual("Bill", lst[1].FirstName);
    			Assert.AreEqual("Gates", lst[1].LastName);
    			Assert.AreEqual(1955, lst[1].Birth);
    			Assert.AreEqual("Steve", lst[2].FirstName);
    			Assert.AreEqual("Jobs", lst[2].LastName);
    			Assert.AreEqual(1955, lst[2].Birth);
    		}
    
    		[TestMethod]
    		public void ReadInheritedPersons()
    		{
    			string xml = @"<?xml version=""1.0"" encoding=""utf-16""?>
    <Persons>
      <Person>
        <FirstName>Linus</FirstName>
        <LastName>Torvalds</LastName>
        <Birth>1969</Birth>
      </Person>
      <Person>
        <FirstName>Bill</FirstName>
        <LastName>Gates</LastName>
        <Birth>1955</Birth>
      </Person>
      <Person>
        <FirstName>Steve</FirstName>
        <LastName>Jobs</LastName>
        <Birth>1955</Birth>
      </Person>
    </Persons>";
    			Persons lst = ReadXml<Persons>(xml);
    			Assert.AreEqual(3, lst.Count);
    			Assert.AreEqual("Linus", lst[0].FirstName);
    			Assert.AreEqual("Torvalds", lst[0].LastName);
    			Assert.AreEqual(1969, lst[0].Birth);
    			Assert.AreEqual("Bill", lst[1].FirstName);
    			Assert.AreEqual("Gates", lst[1].LastName);
    			Assert.AreEqual(1955, lst[1].Birth);
    			Assert.AreEqual("Steve", lst[2].FirstName);
    			Assert.AreEqual("Jobs", lst[2].LastName);
    			Assert.AreEqual(1955, lst[2].Birth);
    		}
    
    		[TestMethod]
    		public void ReadInheritedColors()
    		{
    			string xml = @"<?xml version=""1.0"" encoding=""utf-16""?>
    <colors>
      <color>
        <name>red</name>
        <r>255</r>
    	<g>0</g>
    	<b>0</b>
      </color>
      <color>
    	<name>green</name>
        <r>0</r>
    	<g>255</g>
    	<b>0</b>
      </color>
      <color>
    	<name>yellow</name>
        <r>255</r>
    	<g>255</g>
    	<b>0</b>
      </color>
    </colors>";
    			ColorList lst = ReadXml<ColorList>(xml);
    			Assert.AreEqual(3, lst.Count);
    			Assert.AreEqual("red", lst[0].Name);
    			Assert.AreEqual(255, lst[0].Red);
    			Assert.AreEqual(0, lst[0].Green);
    			Assert.AreEqual(0, lst[0].Blue);
    			Assert.AreEqual("green", lst[1].Name);
    			Assert.AreEqual(0, lst[1].Red);
    			Assert.AreEqual(255, lst[1].Green);
    			Assert.AreEqual(0, lst[1].Blue);
    			Assert.AreEqual("yellow", lst[2].Name);
    			Assert.AreEqual(255, lst[2].Red);
    			Assert.AreEqual(255, lst[2].Green);
    			Assert.AreEqual(0, lst[2].Blue);
    		}
    
    		[TestMethod]
    		public void WriteEmpty()
    		{
    			string xml = @"<?xml version=""1.0"" encoding=""utf-16""?>
    <XmlSerializableListOfInt32 />";
    			XmlSerializableList<int> lst = new XmlSerializableList<int>();
    			string result = WriteXml(lst);
    			Assert.AreEqual(xml, result);
    		}
    
    		[TestMethod]
    		public void WriteSimpleItems()
    		{
    			string xml = @"<?xml version=""1.0"" encoding=""utf-16""?>
    <XmlSerializableListOfInt32>
      <int>0</int>
      <int>52</int>
      <int>79</int>
    </XmlSerializableListOfInt32>";
    			XmlSerializableList<int> lst = new XmlSerializableList<int>() {0, 52, 79};
    			string result = WriteXml(lst);
    			Assert.AreEqual(xml, result);
    		}
    
    		[TestMethod]
    		public void WriteComplexItems()
    		{
    			string xml = @"<?xml version=""1.0"" encoding=""utf-16""?>
    <XmlSerializableListOfPerson>
      <Person>
        <FirstName>Linus</FirstName>
        <LastName>Torvalds</LastName>
        <Birth>1969</Birth>
      </Person>
      <Person>
        <FirstName>Bill</FirstName>
        <LastName>Gates</LastName>
        <Birth>1955</Birth>
      </Person>
      <Person>
        <FirstName>Steve</FirstName>
        <LastName>Jobs</LastName>
        <Birth>1955</Birth>
      </Person>
    </XmlSerializableListOfPerson>";
    			XmlSerializableList<Person> persons = new XmlSerializableList<Person>
    			{
    				new Person {FirstName = "Linus", LastName = "Torvalds", Birth = 1969},
    				new Person {FirstName = "Bill", LastName = "Gates", Birth = 1955},
    				new Person {FirstName = "Steve", LastName = "Jobs", Birth = 1955}
    			};
    			string result = WriteXml(persons);
    			Assert.AreEqual(xml, result);
    		}
    
    		[TestMethod]
    		public void WriteInheritedPersons()
    		{
    			string xml = @"<?xml version=""1.0"" encoding=""utf-16""?>
    <Persons>
      <Person>
        <FirstName>Linus</FirstName>
        <LastName>Torvalds</LastName>
        <Birth>1969</Birth>
      </Person>
      <Person>
        <FirstName>Bill</FirstName>
        <LastName>Gates</LastName>
        <Birth>1955</Birth>
      </Person>
      <Person>
        <FirstName>Steve</FirstName>
        <LastName>Jobs</LastName>
        <Birth>1955</Birth>
      </Person>
    </Persons>";
    			Persons lst = new Persons
    			{
    				new Person {FirstName = "Linus", LastName = "Torvalds", Birth = 1969},
    				new Person {FirstName = "Bill", LastName = "Gates", Birth = 1955},
    				new Person {FirstName = "Steve", LastName = "Jobs", Birth = 1955}
    			};
    			string result = WriteXml(lst);
    			Assert.AreEqual(xml, result);
    		}
    
    		[TestMethod]
    		public void WriteInheritedColors()
    		{
    			string xml = @"<?xml version=""1.0"" encoding=""utf-16""?>
    <colors>
      <color>
        <name>red</name>
        <r>255</r>
        <g>0</g>
        <b>0</b>
      </color>
      <color>
        <name>green</name>
        <r>0</r>
        <g>255</g>
        <b>0</b>
      </color>
      <color>
        <name>yellow</name>
        <r>255</r>
        <g>255</g>
        <b>0</b>
      </color>
    </colors>";
    			ColorList lst = new ColorList
    			{
    				new ColorDefinition { Name = "red", Red = 255, Green = 0, Blue = 0 },
    				new ColorDefinition { Name = "green", Red = 0, Green = 255, Blue = 0 },
    				new ColorDefinition { Name = "yellow", Red = 255, Green = 255, Blue = 0 }
    			};
    			string result = WriteXml(lst);
    			Assert.AreEqual(xml, result);
    		}
    	}
    }
