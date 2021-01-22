    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    class ColumnDefinition : IEquatable<ColumnDefinition>
    {
    	public string Name { get; set; }
    	public string Type { get; set; }
    	public string Attr { get; set; }
    	
    	public ColumnDefinition()
    	{
    		Name = string.Empty;
    		Type = string.Empty;
    		Attr = string.Empty;
    	}
    	
    	public bool Equals(ColumnDefinition other)
    	{	
    		return Name.Equals(other.Name) && Type.Equals(other.Type) && Attr.Equals(other.Attr);
    	}
    
    	public override bool Equals(object value)
    	{
    		return (value is ColumnDefinition) ? Equals(value as ColumnDefinition) : false;
    	}
    	
    	public override int GetHashCode()
    	{
    		return Name.GetHashCode() ^ Type.GetHashCode() ^ Attr.GetHashCode();
    	}
    	
    	public override string ToString()
    	{
    		return string.Concat("{", Name, ":", Type, ":", Attr, "}");
    	}
    }
    
    public class Program
    {
    	public static void Main(string[] args)
    	{
    		try
    		{
    			MyMain(args);
    		}
    		catch (Exception e)
    		{
    			Console.WriteLine(e);
    		}
    		finally
    		{
    			Console.ReadKey();
    		}
    	}
    	
    	public static void MyMain(string[] args)
    	{
    		var list1 = new []  
    			{ 
    				new ColumnDefinition { Name = "foo", Type = "int", Attr = "0" }, 
    				new ColumnDefinition { Name = "bar", Type = "int", Attr = "1" }, 
    			};
    
    		var list2 = new [] 
    			{ 
    				new ColumnDefinition { Name = "foo", Type = "int", Attr = "0" }, 
    				new ColumnDefinition { Name = "bar", Type = "string", Attr = "1" }, 
    			};
    			
    		foreach (var changed in Enumerable.Except(list1, list2))
    		{
    			Console.WriteLine(changed);
    		}
    	}
    }
