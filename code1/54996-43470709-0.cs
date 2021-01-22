    using System;
    using System.Collections.Generic;
    
    namespace GenericProxy
    {
    	class Program
    	{
    		static void Main()
    		{
    			GenericProxy<ClientBase> proxy = new GenericProxy<ClientBase>(ClientBase.Factory, "cream");
    
    			Console.WriteLine(proxy.Proxy.ConfigName); // test to see it working
    		}
    	}
    	
    	public class ClientBase
    	{
    		static public ClientBase Factory(string configName)
    		{
    			return new ClientBase(configName);
    		}
    
    		// default constructor as required by new() constraint
    		public ClientBase() { }
    
    		// constructor that takes arguments
    		public ClientBase(string configName) { _configName = configName; }
    
    		// simple method to demonstrate working example
    		public string ConfigName
    		{
    			get { return "ice " + _configName; }
    		}
    
    		private string _configName;
    	}
    
    	public class GenericProxy<T>
    		where T : ClientBase, new()
    	{
    		public GenericProxy(Func<string, T> factory, string configName)
    		{
    			Proxy = factory(configName);
    		}
    
    		public T Proxy { get; private set; }
    	}
    }
