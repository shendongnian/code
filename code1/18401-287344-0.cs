    using System.Text.RegularExpressions;
    string text = "changed from 1 to 10";
    string pattern = @"(?<digit>\d+)";
    Regex r = new Regex(pattern);
    MatchCollection mc = r.Matches(text);
    foreach (Match m in mc) {
    	CaptureCollection cc = m.Groups["digit"].Captures;
    	foreach (Capture c in cc){
    		Console.WriteLine((Convert.ToInt32(c.Value)));
    	}
    }
