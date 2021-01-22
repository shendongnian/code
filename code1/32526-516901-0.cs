    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    
    namespace ConsoleApplication22
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			List<BaseClass> source = new List<BaseClass>();
    			source.Add(new DerivedClass { Name = "One" });
    			source.Add(new BaseClass());
    			source.Add(new DerivedClass { Name = "Three" });
    
    			List<DerivedClass> result =
    				new List<DerivedClass>(source.OfType<DerivedClass>());
    			result.ForEach(i => Console.WriteLine(i.Name));
    			Console.ReadLine();
    		}
    	}
    
    	public class BaseClass
    	{
    	}
    
    	public class DerivedClass : BaseClass
    	{
    		public string Name { get; set; }
    	}
    
    }
