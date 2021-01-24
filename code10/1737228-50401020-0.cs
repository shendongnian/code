    char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
    
    string text = "one\ttwo three:four,five six seven";
    System.Console.WriteLine($"Original text: '{text}'");
    
    string[] words = text.Split(delimiterChars);
    System.Console.WriteLine($"{words.Length} words in text:");
    
    foreach (var word in words)
    {
        System.Console.WriteLine($"<{word}>");
    }
