    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    class Example {
    
    	static void Main() {
    		string[] strings = new string[]{
    			"name: abc name: def name: ghi name: jkl",
    			"name: abc x name: def name: ghi name: jkl"
    		};
    		Regex regex = new Regex(@"^(?:name: *([a-z]+) *)+$");
    		foreach(string s in strings) {
    			if(regex.IsMatch(s)) {
    				Match match = regex.Match(s);
    				Console.WriteLine(string.Join(", ", from Capture c in match.Groups[1].Captures select c.Value));
    			} else {
    				Console.WriteLine("Invalid input");
    			}
    		}
    	}
    }
