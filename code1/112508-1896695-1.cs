    foreach (Match m in Regex.Matches("b|123|1,op|999", "([^|,]+),([^|,]+)|([^|,]+)")) {
       string value3 = m.Groups[3].Value;
       if (value3.Length > 0) {
          Options.Add(value3, value3);
       } else {
          Options.Add(m.Groups[1].Value, m.Groups[2].Value);
       }
    }
