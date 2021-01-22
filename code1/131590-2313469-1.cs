    // using System.Text.RegularExpressions;
    string test1 = "FirstName=ABC;LastName=XZY;Username=User1;Password=1234";
    string test2 = "FirstName=ABC;LastName=XZY;Password=1234;Username=User1";
    string test3 = "FirstName=ABC;LastName=XZY;Password=1234";
    string regexPattern = @"(?<=Username=)[^;\n]*";
    var userName1 = Regex.Match(test1, regexPattern).Value; // User1
    var userName2 = Regex.Match(test2, regexPattern).Value; // User1
    var userName3 = Regex.Match(test3, regexPattern).Value; // string.Empty
    
    // Compiling can speed up the Regex, at the expense of longer initial Initialization
    // Use when this is called often, but measure.
    Regex compiledRx = new Regex(regexPattern,RegexOptions.Compiled);
    var userNameCompiled1 = compiledRx.Match(test1).Value; // User1
    var userNameCompiled2 = compiledRx.Match(test2).Value; // User1
    var userNameCompiled3 = compiledRx.Match(test3).Value; // string.Empty
