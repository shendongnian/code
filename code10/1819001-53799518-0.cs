    using System.Text.RegularExpressions;
    
    Regex tupleRegex = new Regex(@"{""Item1"": ("".+?""), ""Item2"": (.+?)}");
    string tupleString = @"{""Item1"": ""MyProperty"", ""Item2"": <value>}";
    string tupleToKeyValuePairResult = tupleRegex.Replace(tupleString, "{$1: $2}");
    Console.WriteLine(tupleToKeyValuePairResult);
    Regex kvpRegex = new Regex(@"{("".+?""): (.+?)}");
    string kvpToTupleResult = kvpRegex.Replace(tupleToKeyValuePairResult, @"{""Item1"": $1, ""Item2"": $2}");
    Console.WriteLine(kvpToTupleResult);
