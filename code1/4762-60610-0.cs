    using System;
    using System.IO;
    using System.Xml;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    
    public class Inner
    {
    	private string _AnotherStringProperty;
    	public string AnotherStringProperty 
        { 
          get { return _AnotherStringProperty; } 
          set { _AnotherStringProperty = value; } 
        }
    }
    
    public class DataClass
    {
    	private string _StringProperty;
    	public string StringProperty 
        { 
           get { return _StringProperty; } 
           set{ _StringProperty = value; } 
        }
    	
    	private Inner _InnerObject;
    	public Inner InnerObject 
        { 
           get { return _InnerObject; } 
           set { _InnerObject = value; } 
        }
    }
    
    public class MyClass
    {
    	
    	public static void Main()
    	{
    		try
    		{
    			XmlSerializer serializer = new XmlSerializer(typeof(DataClass));
    			TextWriter writer = new StreamWriter(@"c:\tmp\dataClass.xml");
    			DataClass clazz = new DataClass();
    			Inner inner = new Inner();
    			inner.AnotherStringProperty = "Foo2";
    			clazz.InnerObject = inner;
    			clazz.StringProperty = "foo";
    			serializer.Serialize(writer, clazz);
    		}
    		finally
    		{
    			Console.Write("Press any key to continue...");
    			Console.ReadKey();
    		}
    	}
    
    }
