    string wordsToMatch = "memory|buffer overflow|address space|stack overflow|call stack";
    string sentence = "In software, a stack overflow occurs if the call stack pointer exceeds the stack bound. The call stack may consist of a limited amount of address space, often determined at the start of the program. The size of the call stack depends on many factors, including the programming language, machine architecture, multi-threading, and amount of available memory. When a program attempts to use more space than is available on the call stack (that is, when it attempts to access memory beyond the call stack's bounds, which is essentially a buffer overflow), the stack is said to overflow, typically resulting in a program crash.";
    
    int wordCount = 0;
    var wordsFound = new List<string>();
    foreach (string word in wordsToMatch.Split('|')) {
        foreach (Match match in Regex.Matches(sentence, word, RegexOptions.IgnoreCase)) {
           if (match.Value.Equals(word)) {
               wordsFound.Add(match.Value);
               wordCount++;
           }
        }
    }
    Console.WriteLine("Found: " + string.Join(",", wordsFound));
    Console.WriteLine("Count: " + wordCount);
