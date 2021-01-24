    var value = @"14 S 20 ? OSE ? NHY ""Norsk Hydro"" NO0005052605 1 ""20180921"" 48.6 2068998276 NOK S I ? ? 1 Y"+"\n";
    var pattern = new Regex(@"^(""(.*?)""|[^ ""]+)( (""(.*?)""|[^ ""]+)){19,19}\n$");
    var match = pattern.Match(value);
    if (match.Success)
    {
        for (int ctr = 1; ctr < match.Groups.Count; ctr++)
        {
            Console.WriteLine("   Group {0}:  {1}", ctr, match.Groups[ctr].Value);
            int captureCtr = 0;
            foreach (Capture capture in match.Groups[ctr].Captures)
            {
                Console.WriteLine("      Capture {0}: {1}",
                    captureCtr, capture.Value);
                captureCtr++;
            }
        }
    }
