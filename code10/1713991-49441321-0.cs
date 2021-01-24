      var st = "New Specification Result :    Measures 0.0039mm(4 Microns)New Specification Result: Measures 0.0047mm(5 Microns";
      var pattern = @"([0-9]\.[0-9]{4}mm)";
      var expr = new Regex(pattern, RegexOptions.IgnoreCase);
      string key = "";
      foreach (Match match in expr.Matches(st))
      {
        key += match.Groups[1].Value;
      }
