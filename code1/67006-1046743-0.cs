    using System.Text.RegularExpressions;
    Regex r = new Regex("^[a-zA-Z0-9]*$");
    if (r.IsMatch(SomeString)) {
      ...
    }
