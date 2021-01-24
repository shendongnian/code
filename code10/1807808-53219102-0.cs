    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    
    public enum MyEnum
    {
    	Red,
    	Green,
    	Blue
    }
    public class MyClass
    {
    	public HashSet<MyEnum> MyHashSetOfEnums	{ get; private set;	}
    	public MyClass() {
    		MyHashSetOfEnums = new HashSet<MyEnum>(); 
    	}
    }
    public class Program
    {
    	public static void Main()
    	{
    		var set = new MyClass();
    		set.MyHashSetOfEnums.Add(MyEnum.Blue);
    		set.MyHashSetOfEnums.Add(MyEnum.Red);
    		
    		var xs = new XmlSerializer(typeof(MyClass));
    		string xml;
    		using (var writer = new StringWriter())	{
    			xs.Serialize(writer, set);
    			xml = writer.ToString();
    			Console.WriteLine(xml);
    		}
    		using (var reader = new StringReader(xml)) {
    			var set2 = (MyClass)xs.Deserialize(reader);
    			foreach (MyEnum s in set2.MyHashSetOfEnums)
    				Console.WriteLine(s);
    		}
    	}
    }
