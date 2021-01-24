    using System;
    using System.Text.RegularExpressions;
    
    namespace RE {
    	class TEST {
    		static void Main(string[] args) {
    			// Your string
    			var str = "2018-12-26P18:07:05:07";
    			// Regex to match 18 and 07 to 1 and second group.
    			var re = new Regex(@"\d+-\d+-\d+[A-z](\d+):(\d+)");
    			// Execute regex over string, and get our matched groups
    			var match = re.Match(str);
    			// Write the groups.
    			Console.WriteLine(match.Groups[1].Value + match.Groups[2].Value);
    		}
    	}
    }
