    using System.Linq;
    using System.Text.RegularExpressions;
    ...
    string input = "E5-20-36-32-37-20-E0";
    string result = Regex
      .Replace(input, 
              @"(?<=20\-)3[0-9](\-3[0-9])*(?=\-20)", 
               match => string.Join("-", match.Value.Split('-').Reverse()));
