    using System;
    using System.Globalization;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var hindiCulture = new CultureInfo("hi-IN");
    		Console.WriteLine(hindiCulture.EnglishName);
    		Console.WriteLine(hindiCulture.NativeName);
    		Console.WriteLine(string.Join("", hindiCulture.NumberFormat.NativeDigits));
    	}
    }
