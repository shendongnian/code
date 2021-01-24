    using System;
    using static LibraryName.WebServicesName;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine(EnumName.Foo);
    	}
    }
    
    namespace LibraryName
    {
    	class WebServicesName{
    	
    		public enum EnumName { Foo, Bar}
    	}
    }
