    string pattern = @"^1:\d{1,3}$";
    Console.WriteLine(Regex.IsMatch("1:1", pattern)); // true
    Console.WriteLine(Regex.IsMatch("1:34", pattern)); // true
    Console.WriteLine(Regex.IsMatch("1:847", pattern)); // true
    Console.WriteLine(Regex.IsMatch("1:2322", pattern)); // false
