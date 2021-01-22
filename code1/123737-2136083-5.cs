    public string LowerCaseLipsum
    {
      get
      {
        //went to lipsum.com and generated 10 paragraphs of lipsum
        //which I then initialised into the backing field with @"[lipsumtext]".ToLower()
        return _lowerCaseLipsum;
      }
     }
     [TestMethod]
     public void CapitaliseAhmadsWay()
     {
       List<string> results = new List<string>();
       DateTime start = DateTime.Now;
       Regex r = new Regex(@"(^|\p{P}\s+)(\w+)", RegexOptions.Compiled);
       for (int f = 0; f < 1000; f++)
       {
         results.Add(r.Replace(LowerCaseLipsum, m => m.Groups[1].Value
	                      + m.Groups[2].Value.Substring(0, 1).ToUpper()
                               + m.Groups[2].Value.Substring(1)));
       }
       TimeSpan duration = DateTime.Now - start;
       Console.WriteLine("Operation took {0} seconds", duration.TotalSeconds);
     }
       
     [TestMethod]
     public void CapitaliseLookAroundWay()
     {
       List<string> results = new List<string>();
       DateTime start = DateTime.Now;
       Regex r = new Regex(@"(?<=(^|[.;:])\s*)[a-z]", RegexOptions.Compiled);
       for (int f = 0; f < 1000; f++)
       {
         results.Add(r.Replace(LowerCaseLipsum, m => m.Value.ToUpper()));
       }
       TimeSpan duration = DateTime.Now - start;
       Console.WriteLine("Operation took {0} seconds", duration.TotalSeconds);
     }
