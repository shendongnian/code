    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var keyValue = new KeyValuePair<string,string>("FullName", "John");
    		string docText = "Dear {{FullName}}";
            string result = docText.Replace("{{" + keyValue.Key + "}}", keyValue.Value);
    		Console.WriteLine(result);
    	}
    }
