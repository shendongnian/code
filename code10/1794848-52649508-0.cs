    using System.Linq;
    ...
    string source = "qwerty";
    string[] chunks = new string[] { 
      "qwe", "wer", "ert", "rty", "tuy", "yui", "uio", "iop"};
    string[] appeared = chunks
      .Where(chunk => source.IndexOf(chunk, StringComparison.OrdinalIgnoreCase) >= 0)
      .ToArray();
    Console.Write(string.Join(", ", appeared));
 
