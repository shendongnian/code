    using System;
    using System.Reflection;
    
    namespace Test
    {
    	public class Class1
    	{
    		static Class1()
    		{
    			Console.WriteLine("Class1: static constructor");
    		}
    		
    		public static void Initialize()
    		{
    			Console.WriteLine("Class1: initialize method");
    		}
    	}
    	
    	public static class Class2
    	{
    		public static void Initialize()
    		{
    			Console.WriteLine("Class2: initialize method");
    		}
    	}
    
    	
    	class MainClass
    	{
    		public static void InvokeImplicitInitializers(Assembly assembly)
    		{
    			foreach (Type type in assembly.GetTypes())
    			{
    				MethodInfo mi = type.GetMethod("Initialize");
    				if (mi != null) 
    				{
    					mi.Invoke(null, null);
    				}
    			}
    		}
    		
    		public static void Main (string[] args)
    		{
    			InvokeImplicitInitializers(Assembly.GetCallingAssembly());
    		}
    	}
    }
