    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var hindiCulture = new CultureInfo("hi-IN");
    		Console.WriteLine(hindiCulture.EnglishName);
    		Console.WriteLine(hindiCulture.NativeName);
    		Console.WriteLine(string.Join("", hindiCulture.NumberFormat.NativeDigits));
    		Console.WriteLine(
                ConvertToMyLanguageDigits("0123456789", 
                hindiCulture.NumberFormat.NativeDigits));
    	}
    	
    	private static string ConvertToMyLanguageDigits(string number, string[] myNative)
            {
                string myNewMuber = string.Empty;
                myNewMuber = number;
                Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                string number1 = rgx.Replace(number, "");
                var aa = number1.ToCharArray().Distinct().ToArray();
                foreach (var item in aa)
                {
                    if (!myNative.Any(x => x.Contains(item)))
                    {
                        myNewMuber = myNewMuber.Replace(
                            item.ToString(), 
                            myNative[int.Parse(item.ToString())].ToString());
                    }
                }
                return myNewMuber;
           }
    }
