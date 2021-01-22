    // using System.Text.RegularExpressions;
    string test1 = "FirstName=ABC;LastName=XZY;Username=User1;Password=1234";
    string test2 = "LastName=XZY;Username=User1;Password=1234;FirstName=ABC";
    string test3 = "LastName=XZY;Username=User1;Password=1234";
    string regexPattern = @"(?<=FirstName=)[^;\n]*";
    var firstName1 = Regex.Match(test1, regexPattern).Value; // ABC
    var firstName2 = Regex.Match(test2, regexPattern).Value; // ABC
    var firstName3 = Regex.Match(test3, regexPattern).Value; // string.Empty
    
    // Compiling can speed up the Regex, at the expense of longer initial Initialization
    // Use when this is called often, but measure.
    Regex compiledRx = new Regex(regexPattern,RegexOptions.Compiled);
    var firstNameCompiled1 = compiledRx.Match(test1).Value; // ABC
    var firstNameCompiled2 = compiledRx.Match(test2).Value; // ABC
    var firstNameCompiled3 = compiledRx.Match(test3).Value; // string.Empty
