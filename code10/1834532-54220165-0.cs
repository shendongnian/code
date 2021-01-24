    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Newtonsoft.Json;
    
    public class Program
    {
    	public static void Main()
    	{
    		var inputs = new List<object>()
    		{new Foo{Prop2 = "" , Bar = new Bar()}};
    		foreach (object input in inputs)
    		{
    			string NormalSerialisation = JsonConvert.SerializeObject(input, Formatting.Indented, new JsonSerializerSettings{});
    			string CustomSerialisation = JsonConvert.SerializeObject(input, Formatting.Indented, new JsonSerializerSettings{NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore});
    			Console.WriteLine("normal:");
    			Console.WriteLine(NormalSerialisation);
    			Console.WriteLine("custom:");
    			Console.WriteLine(CustomSerialisation);
    		}
    	}
    
    	public class Foo
    	{
    		
    		public string Prop2
    		{
    			get;
    			set;
    		}
    
    		public Bar Bar
    		{
    			get;
    			set;
    		}
    	}
    
    	public class Bar
    	{
    		[DefaultValue("")]
    		public string Prop2;
    	}
    }
