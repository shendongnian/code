    using System;
    using System.Text.RegularExpressions;
    
    namespace test
    {
    	class MainClass
    	{
    		public static void Main(string[] args)
    		{
    			var names = new string[]{"Hello World", 
    				"John",
    				"João",
    				"タロウ",
    				"やまだ",
    				"山田",
    				"先生",
    				"мыхаыл",
    				"Θεοκλεια",
    				"आकाङ्क्षा",
    				"علاء الدين",
    				"אַבְרָהָם",
    				"മലയാളം",
    				"상",
    				"D'Addario",
    				"John-Doe",
    				"P.A.M.",
    				"' --",
    				"<xss>",
    				"\""
    			};
    			foreach (var nameParam in names)
    			{
    				Console.Write(nameParam+" ");
    				var name = nameParam.Trim();
    				if (!Regex.IsMatch(name, @"^[\p{L}\p{M}' \.\-]+$"))
    				{
    					Console.WriteLine("fail");
    					continue;
    				}
    				name = name.Replace("'", "&#39;");
    				Console.WriteLine(name);
    			}
    		}
    	}
    }
