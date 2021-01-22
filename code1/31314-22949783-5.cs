    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace DataTypes {
    	[TestClass]
    	public class SerializableDictionaryTests {
    		[TestMethod]
    		public void TestStringStringDict() {
    			var dict = new SerializableDictionary<string, string>();
    			dict.Add("Grass", "Green");
    			dict.Add("Snow", "White");
    			dict.Add("Sky", "Blue");
    			dict.Add("Tomato", "Red");
    			dict.Add("Coal", "Black");
    			dict.Add("Mud", "Brown");
    
    			var serializer = new System.Xml.Serialization.XmlSerializer(dict.GetType());
    			using (var stream = new MemoryStream()) {
    				// Load memory stream with this objects xml representation
    				XmlWriter xmlWriter = null;
    				try {
    					xmlWriter = XmlWriter.Create(stream);
    					serializer.Serialize(xmlWriter, dict);
    				} finally {
    					xmlWriter.Close();
    				}
    				
    				// Rewind
    				stream.Seek(0, SeekOrigin.Begin);
    
    				XDocument doc = XDocument.Load(stream);
    				Assert.AreEqual("Dictionary", doc.Root.Name);
    				Assert.AreEqual(dict.Count, doc.Root.Descendants().Count());
    				
    				// Rewind
    				stream.Seek(0, SeekOrigin.Begin);
    				var outDict = serializer.Deserialize(stream) as SerializableDictionary<string, string>;
    				Assert.AreEqual(dict["Grass"], outDict["Grass"]);
    				Assert.AreEqual(dict["Snow"], outDict["Snow"]);
    				Assert.AreEqual(dict["Sky"], outDict["Sky"]);
    			}
    		}
    
    		[TestMethod]
    		public void TestIntIntDict() {
    			var dict = new SerializableDictionary<int, int>();
    			dict.Add(4, 7);
    			dict.Add(5, 9);
    			dict.Add(7, 8);
    
    			var serializer = new System.Xml.Serialization.XmlSerializer(dict.GetType());
    			using (var stream = new MemoryStream()) {
    				// Load memory stream with this objects xml representation
    				XmlWriter xmlWriter = null;
    				try {
    					xmlWriter = XmlWriter.Create(stream);
    					serializer.Serialize(xmlWriter, dict);
    				} finally {
    					xmlWriter.Close();
    				}
    
    				// Rewind
    				stream.Seek(0, SeekOrigin.Begin);
    
    				XDocument doc = XDocument.Load(stream);
    				Assert.AreEqual("Dictionary", doc.Root.Name);
    				Assert.AreEqual(3, doc.Root.Descendants().Count());
    
    				// Rewind
    				stream.Seek(0, SeekOrigin.Begin);
    				var outDict = serializer.Deserialize(stream) as SerializableDictionary<int, int>;
    				Assert.AreEqual(dict[4], outDict[4]);
    				Assert.AreEqual(dict[5], outDict[5]);
    				Assert.AreEqual(dict[7], outDict[7]);
    			}
    		}
    	}
    }
