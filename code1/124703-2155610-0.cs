    string test = @"public static SomeReturnType GetSomething(string param1, int param2)";
    var match = Regex.Match(test, @"(?<scope>\w+)\s+(?<static>static\s+)?(?<return>\w+)\s+(?<name>\w+)\((?<parms>[^)]+)\)");
    Console.WriteLine(match.Groups["scope"].Value);
    Console.WriteLine(!string.IsNullOrEmpty(match.Groups["static"].Value));
    Console.WriteLine(match.Groups["return"].Value);
    Console.WriteLine(match.Groups["name"].Value);
    List<string> parms = match.Groups["parms"].ToString().Split(',').ToList();
    parms.ForEach(x => Console.WriteLine(x));
    Console.Read();
