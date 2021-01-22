    static void Main()
    {
        string textWithDuplicates = "aaabbcccggg";     
    
        Console.WriteLine(textWithDuplicates.Count());  
        var letters = new HashSet<char>(textWithDuplicates);
        Console.WriteLine(letters.Count());
    
        foreach (char c in letters) Console.Write(c);
        Console.WriteLine("");
    
        int[] array = new int[] { 12, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2 };
        
        Console.WriteLine(array.Count());
        var distinctArray = new HashSet<int>(array);
        Console.WriteLine(distinctArray.Count());
    
        foreach (int i in distinctArray) Console.Write(i + ",");
    }
