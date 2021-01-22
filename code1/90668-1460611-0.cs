    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Collections.Generic;
    
    class Program
    {
    	static void Main()
    	{
    		String xml = @"<fruits>
    				<fruit>
    					<id>1</id>
    					<name>apple</name>
    				</fruit>
    				<fruit>
    					<id>2</id>
    					<name>orange</name>
    				</fruit>
    			</fruits>";
    
    		IEnumerable<Fruit> fruit = XElement.Parse(xml)
    			.Elements("fruit")
    			.Select(f => new Fruit
    			{
    				name = f.Element("name").Value,
    				id = Int32.Parse(f.Element("id").Value)
    			});
    	}
    }
    
    public class Fruit
    {
    	public string name;
    	public int id;
    }
