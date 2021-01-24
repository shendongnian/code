    using System.Linq;
    ...
    string text = "Z programovani{}{}{}";
    // Let's use Linq; loop 
    // for(int i = 0; i < 26; ++i) Console.WriteLine($"{i,2}: {Caesar(text, i)}");  
    // is an alternative
    string result = string.Join(Environment.NewLine, Enumerable
      .Range(0, 26)
      .Select(i => $"{i,2}: {Caesar(text, i)}"));
 
    Console.Write(result);
