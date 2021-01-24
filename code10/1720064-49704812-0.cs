    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Globalization;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		string rawInput = "ἀἁἂἃἄἅἆἇὰάᾀᾁᾂᾃᾄᾅᾆᾇᾰᾱᾲᾳᾴᾶᾷ";
    		Console.WriteLine(rawInput);
    		string normalizedInput = Utility.RemoveDiacritics(rawInput);    
    		string pattern = "α+";
            
            var result = Regex.Matches(normalizedInput, pattern);
    		if(result.Count > 0)
    			Console.WriteLine(result[0]);    
    	}
    }
    
    public static class Utility
    {
        public static string RemoveDiacritics(this string str)
        {
            if (null == str) return null;
            var chars =
                from c in str.Normalize(NormalizationForm.FormD).ToCharArray()
                let uc = CharUnicodeInfo.GetUnicodeCategory(c)
                where uc != UnicodeCategory.NonSpacingMark
                select c;
    
            return new string(chars.ToArray()).Normalize(NormalizationForm.FormC);
        }
    }
