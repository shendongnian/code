      using System.Text.RegularExpressions;
   
      ...
      string source = "hello 1234 bye"; 
      string result = Regex.Replace(source, "[0-9]+", "$0,");
