    // using System.Text.RegularExpressions
    Regex rx = new Regex(@"\[ID\s*=\s*(\d+)\]", RegexOptions.IgnoreCase);
    foreach (var s in sNames)
    {
      Match m = rx.Match(s);
      if (!m.Success) continue; // Couldn't find ID.
      int id = Convert.ToInt32(m.Groups[1].ToString());
      // ...
    }
