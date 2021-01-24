    Console.Write("Enter number of words per line: ");
    int wordsPerLine = int.Parse(Console.ReadLine());
    string source = @""; // fill in your text here
    string[] words = source.Split(' ');
    for (int i = 0; i < words.Length; i++) {
        if (i % wordsPerLine == 0) {
            Console.WriteLine();
        }
        Console.Write(words[i]);
        Console.Write(" ");
    }
    Console.ReadLine();
