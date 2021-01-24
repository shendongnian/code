    using System.Linq;
    ...
    string text = "Z programovani{}{}{}";
    string result = string.Join(Environment.NewLine, Enumerable
      .Range(0, 26)
      .Select(i => $"{i,2}: {Caesar(text, i)}"));
 
    Console.Write(result);
