    int multiplier = 3;
    string input =
      "damagebase = 8.834\n" +
      "  \"abc.odf\" 3.77\n" +
      "  \"def.odf\" 3.77\n" +
      "  \"ghi.odf\" .77\n" +
      "  \"jkl.odf\" -4.05\n" +
      "  \"mno.odf\" 5\n";
    Regex r = new Regex(@"^(\w+)\s*=\s*(\S+)" +
                        @"(?:\s+""([^""]+)""\s+(\S+))+",
                        RegexOptions.Compiled);
    Match m = r.Match(input);
    if (m.Success) {
      double header = Double.Parse(m.Groups[2].Value);
      Console.WriteLine("{0} = {1}", m.Groups[1].Value,
                                     header * multiplier);
      CaptureCollection files = m.Groups[3].Captures;
      CaptureCollection nums  = m.Groups[4].Captures;
      for (int i = 0; i < files.Count; i++) {
        double val = Double.Parse(nums[i].Value);
        Console.WriteLine(@"  ""{0}"" {1}", files[i].Value,
                                            val * multiplier);
      }
    }
    else
      Console.WriteLine("no match");
