    using System;
    using System.Reflection;
    
    [Serializable]
    public class SerializableClass
    {
    	public string WhatIsMyAppDomain()
    	{
    		return AppDomain.CurrentDomain.FriendlyName;
    	}
    }
    
    public class MarshallByRefClass : MarshalByRefObject
    {
    	public string WhatIsMyAppDomain()
    	{
    		return AppDomain.CurrentDomain.FriendlyName;
    	}
    }    
    
    class Test
    {
    
    	static void Main(string[] args)
    	{
    		AppDomain ad = AppDomain.CreateDomain("OtherAppDomain");
    
    		MarshallByRefClass marshall = (MarshallByRefClass)ad.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName, "MarshallByRefClass");
    		SerializableClass serializable = (SerializableClass)ad.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName, "SerializableClass");
    
    		Console.WriteLine(marshall.WhatIsMyAppDomain());
    		Console.WriteLine(serializable.WhatIsMyAppDomain());
    
    	}
    }
