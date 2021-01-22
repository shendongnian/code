    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;
    using System.IO;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static void Main()
    		{
    			string xml =
    				"<?xml version=\"1.0\"?>" + 
    				"<config>" +
    				"<stuff>" + 
    				"  <class1 prop1=\"foo\" prop2=\"bar\"></class1>" +
    				"  <class2 prop1=\"FOO\" prop2=\"BAR\" prop3=\"42\"></class2>" +
    				"</stuff>" +
    				"</config>";
    			StringReader sr = new StringReader(xml);
    			XmlSerializer xs = new XmlSerializer(typeof(ThingCollection));
    			ThingCollection tc = (ThingCollection)xs.Deserialize(sr);
    
    			foreach (Thing t in tc.Things)
    			{
    				Console.WriteLine(t.ToString());
    			}
    		}
    	}
    
    	public abstract class Thing
    	{
    	}
    
    	[XmlType(TypeName="class1")]
    	public class SomeThing : Thing
    	{
    		private string pn1;
    		private string pn2;
    
    		public SomeThing()
    		{
    		}
    		
    		[XmlAttribute("prop1")]
    		public string PropertyNumber1
    		{
    			get { return pn1; }
    			set { pn1 = value; }
    		}
    
    		[XmlAttribute("prop2")]
    		public string AnotherProperty
    		{
    			get { return pn2; }
    			set { pn2 = value; }
    		}
    	}
    
    	[XmlType(TypeName="class2")]
    	public class SomeThingElse : SomeThing
    	{
    		private int answer;
    
    		public SomeThingElse()
    		{
    		}
    
    		[XmlAttribute("prop3")]
    		public int TheAnswer
    		{
    			get { return answer; }
    			set { answer =value; }
    		}
    	}
    
    	[XmlType(TypeName = "config")]
    	public class ThingCollection
    	{
    		private List<Thing> things;
    
    		public ThingCollection()
    		{
    			Things = new List<Thing>();
    		}
    
    		[XmlArray("stuff")]
    		[XmlArrayItem(typeof(SomeThing))]
    		[XmlArrayItem(typeof(SomeThingElse))]
    		public List<Thing> Things
    		{
    			get { return things; }
    			set { things = value; }
    		}
    	}
    }
