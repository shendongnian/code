    using System;
    using System.Diagnostics;
    
    namespace Singleton
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			Something.Instance.SayHello();
    		}
    	}
    
    	/// <summary>
    	/// Generic singleton pattern implementation
    	/// </summary>
    	public class SingletonImplementation<Implementation, ImplementationInterface>
    		   where Implementation : class, ImplementationInterface, new()
    	{
    		private SingletonImplementation() { }
    
    		private static Implementation instance = null;
    		public static ImplementationInterface Instance
    		{
    			get
    			{
    				// here you can add your singleton stuff, which you don't like to write all the time
    
    				if ( instance == null )
    				{
    					instance = new Implementation();
    				}
    
    				return instance;
    			}
    		}
    	}
    
    	/// <summary>
    	/// Interface for the concrete singleton
    	/// </summary>
    	public interface ISomething
    	{
    		void SayHello();
    	}
    
    	/// <summary>
    	/// Singleton "held" or "wrapper" which provides the instance of the concrete singleton
    	/// </summary>
    	public static class Something
    	{
    		// No need to define the ctor private, coz you can't do anything wrong or useful with an instance of Something
    		// private Implementation();
    
    		/// <summary>
    		/// Like common: the static instance to access the concrete singleton
    		/// </summary>
    		public static ISomething Instance => SingletonImplementation<ImplementationOfSomething, ISomething>.Instance;
    
    		/// <summary>
    		/// Concrete singleton implementation
    		/// </summary>
    		private class ImplementationOfSomething : ISomething
    		{
    			// No need to define the ctor private, coz the class is private.
    			// private Implementation();
    
    			public void SayHello()
    			{
    				Debug.WriteLine("Hello world.");
    			}
    		}
    	}
    }
