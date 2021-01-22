    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Collections.Generic;
    
    class Program
    {
    	static void Main()
    	{
    		String xml = @"<fruits>
    				<fruit><id>1</id><name>apple</name></fruit>
    				<fruit><id>2</id><name>orange</name></fruit>
    			</fruits>";
    
    		IEnumerable<Fruit> fruit = foo<Fruit>(xml);
    	}
    
    	static IEnumerable<T> foo<T>(String xml)
    		where T : IFruit, new()
    	{
    		return XElement.Parse(xml)
    			.Elements("fruit")
    			.Select(f => new T
    			{
    				name = f.Element("name").Value,
    				id = Int32.Parse(f.Element("id").Value)
    			});
    	}
    }
    
    public interface IFruit
    {
    	String name { get; set; }
    	Int32 id { get; set; }
    }
    
    public class Fruit : IFruit
    {
    	public String name { get; set; }
    	public Int32 id { get; set; }
    }
