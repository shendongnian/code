    var s = "abc,def,2,100,xyz!,:))))";
    Console.WriteLine(Regex.Replace(s, @"(\d),(\d)", "$1$2"));   // Does not handle 1,2,3,4 cases
    Console.WriteLine(Regex.Replace(s, @"(\d),(?=\d)", "$1"));   // Handles consecutive matches with capturing group+backreference/lookahead
    Console.WriteLine(Regex.Replace(s, @"(?<=\d),(?=\d)", ""));  // Handles consecutive matches with lookbehind/lookahead, the most efficient way
    Console.WriteLine(Regex.Replace(s, @",(?<=\d,)(?=\d)", "")); // Also handles all cases
