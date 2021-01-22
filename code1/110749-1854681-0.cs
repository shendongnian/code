    using System.Text.RegularExpressions;
    // ...
    string input = "treand60(12.3)/1010 + 1 >1010";
    Regex regex = new Regex(@"\b\d+(?:\.\d+)?");
    string output = regex.Replace(input, (m) => m.Value + 'c');
    Console.WriteLine(output);  // prints "treand60(12.3c)/1010c + 1c >1010c"
