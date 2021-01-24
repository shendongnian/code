    // Declare Sentence Variable
    string sentence = "The quick brown fox jumps over the lazy dog";
    // Initialize New List of type char
    List<char> charList = new List<char>();
    // Remove Spaces and Lowercase all Letters and Add to List
    charList.AddRange(sentence.Replace(" ", string.Empty).ToLower());
    // Sort List<char>()
    charList.Sort();
    // Output Statements
    Console.WriteLine($"Before: {sentence}");
    Console.WriteLine($"After: {new string(charList.ToArray())}");
