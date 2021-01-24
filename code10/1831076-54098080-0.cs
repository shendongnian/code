    string[] wordList = new string[WordAmount];
    while (i <= WordAmount)
    {
        Console.WriteLine("Enter a word");
        wordList[i-1] = Console.ReadLine() ;
        i++;
    }
    foreach (var item in wordList)
        Console.WriteLine(item + "ba");
