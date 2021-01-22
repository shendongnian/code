    using System.IO;
    using System.Text.RegularExpressions;
    Regex pattern = new Regex("^B");
    List<string> lines = new List<string>();
    using (StreamReader reader = File.OpenText(fileName))
    {
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
             Match patternMatch = pattern.Match(blah);
    
                if (patternMatch.Groups.Count > 0)
                {
                    lines.Add(blah);
                }
        }
    }
