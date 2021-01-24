    var pattern=new Regex(@"^([^ ]+)( (\\""(.*?)\\""|[^ \\]+)){19,19}$");
    var match=pattern.Match(value);
	if (match.Success)
	{	
        foreach (int ctr = 1; ctr < match.Groups.Count; ctr++) {
            Console.WriteLine("   Group {0}:  {1}", ctr, match.Groups[ctr].Value);
            int captureCtr = 0;
            foreach (Capture capture in match.Groups[ctr].Captures) {
                Console.WriteLine("      Capture {0}: {1}", 
                           captureCtr, capture.Value);
                captureCtr++; 
            }
        }
    }
