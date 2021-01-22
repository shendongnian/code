    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication3
    {
    	public class myobj
    	{
    		private string a = string.Empty;
    		private string b = string.Empty;
    
    		public myobj(string a, string b)
    		{
    			this.a = a;
    			this.b = b;
    		}
    
    		public string A
    		{
    			get
    			{
    				return a;
    			}
    		}
    
    		public string B
    		{
    			get
    			{
    				return b;
    			}
    		}
    	}
    
    
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			List<myobj> list = new List<myobj>();
    			myobj[] objects = { new myobj("a", "b"), new myobj("c", "d"), new myobj("a", "b") };
    
    
    			for (int i = 0; i < objects.Length; i++)
    			{
    				if (!list.Exists((delegate(myobj x) { return (string.Equals(x.A, objects[i].A) && string.Equals(x.B, objects[i].B)) ? true : false; })))
    				{
    					list.Add(objects[i]);
    				}
    			}
    		}
    	}
    }
