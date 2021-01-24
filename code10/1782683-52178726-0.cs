      string[] lines = {@"Input File : 'D:\myfile.wav'", @"Duration: 00:00:18.57"};
      Regex regex = new Regex("^[^:]+");
      Dictionary<string, string> dict = new Dictionary<string, string>();
      for (int i = 0; i < lines.Length; i++)
      {
        // match in the string will be everything before first :,
        // then we replace match with empty string and remove first
        // character which will be :, and that will be the value
        string key = regex.Match(lines[i]).Value.Trim();
        string value = regex.Replace(lines[i], "").Remove(0, 1).Trim();
        dict.Add(key, value);
      }
