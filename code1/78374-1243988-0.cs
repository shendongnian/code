    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace InterfacesWithGenerics
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			Helper.PrintClassName<Example>(new Example());
    			Console.ReadLine();
    		}
    	}
    	
    	public class Example : I
    	{
    		#region I Members
    
    		public string ClassName
    		{
    			get { return this.GetClassName(); }
    		}
    
    		#endregion
    	}
    
    	public interface I
    	{
    		string ClassName { get; }
    	}
    
    	public class Helper
    	{
    
    		public static void PrintClassName<T>(T input) where T : I
    		{			
    			Console.WriteLine( input.GetClassName()) ;
    		}
    	}
    
    	public static class IExtensions
    	{
    		public static string GetClassName(this I yourInterface)
    		{
    			return yourInterface.GetType().ToString();
    		}
    	}
    }
