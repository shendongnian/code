    string input = "<p> <br />  </p>";
      string pattern = "<[^<>^]+?>";
      string replacement = "";
      string result1 = Regex.Replace(input, pattern,replacement);
      pattern = "[\s\t\n]*"; ///filter for space, new line, tab 
      string result_final = Regex.Replace(result1 , pattern, replacement);
      if (string.IsNullOrEmpty(result_final)) ... /// empty html
