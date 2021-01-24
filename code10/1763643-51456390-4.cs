    Dictionary<string, string> dict = 
      new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
        { "name", "John"},
        { "age", "34"}
      };
    string script = " The name and the fathersname and age and age_of_father ";
    //  The John and the fathersname and 34 and age_of_father 
    string result = Regex.Replace(
      script,
     @"\w+",   // match each word
      match => dict.TryGetValue(match.Value, out var value) // should the word be replaced? 
        ? value          // yes, replace
        : match.Value);  // no, keep as it is
