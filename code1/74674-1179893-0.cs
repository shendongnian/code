    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization.Json;
    using System.IO;
    using System.Text;
    
    class Program
    {
    	static void Main()
    	{
    		Foo foo = new Foo { Bar = "bar", Baz = "baz" };
    		foo.Items.Add("first", "first");
    
    		DataContractJsonSerializer serializer 
                = new DataContractJsonSerializer(typeof(Foo));
    
    		using (MemoryStream ms = new MemoryStream())
    		{
    			serializer.WriteObject(ms, foo);
    			Console.WriteLine(Encoding.Default.GetString(ms.ToArray()));
    		}
    	}
    }
    
    public class Foo
    {
    	public Dictionary<string, string> Items { get; set; }
    	public string Bar { get; set; }
    	public string Baz { get; set; }
    
    	public Foo()
    	{
    		this.Items = new Dictionary<string, string>();
    	}
    }
