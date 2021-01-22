    using System;
    
    using Ext;
    
    namespace ConsoleApplication26
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			IFoo foo = FooFactory.GetFoo();
    		}
    	}
    }
    // another project/dll
    namespace Ext
    {
    	public interface IFoo
    	{
    		void M ();
    	}
    
    
    	public static class FooFactory
    	{
    		public static IFoo GetFoo ()
    		{
    			return new Foo();
    		}
    	}
    
    
    	class Foo : IFoo
    	{
    		public void M () { }
    	}
    }
