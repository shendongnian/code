    // using System.Text.RegularExpressions;
    // pattern = any number of arbitrary characters between square brackets.
    var pattern = @"\[(.*?)\]";
    var query = "H1-receptor antagonist [HSA:3269] [PATH:hsa04080(3269)]";
    var matches = Regex.Matches(query, pattern);
    
    foreach (Match m in matches) {
        Console.WriteLine(m.Groups[1]);
    }
