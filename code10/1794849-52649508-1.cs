    using System.Linq;
    ...
    string source = "qwerty";
    // either put chunks to test direct
    string[] chunks = new string[] { 
      "qwe", "wer", "ert", "rty", "tuy", "yui", "uio", "iop", "op[", "p[]", "[]\\"};
    // ...or generate them as 3-grams:
    // string line = "qwertyuiop[]\\";
    // string[] chunks = Enumerable
    //   .Range(0, line.Length + 1 - 3)
    //   .Select(start => line.Substring(start, 3))
    //   .ToArray();
    string[] appeared = chunks
      .Where(chunk => source.IndexOf(chunk, StringComparison.OrdinalIgnoreCase) >= 0)
      .ToArray();
    Console.Write(string.Join(", ", appeared));
 
