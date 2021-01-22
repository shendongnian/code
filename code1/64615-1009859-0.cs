    string[] FixedSplit(string s, int len)
    {
       List<string> output;
       while (s.Length > len)
       {
          output.Add(s.Substring(0, len) + "\n");
          s.Remove(0, len);
       }
       output.Add(s + "\n");
       return output.ToArray();
    }
