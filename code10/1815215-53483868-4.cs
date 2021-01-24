    for (var i = 5; i > 0; i--)
    {
        Console.WriteLine(string.Join(" ", 
                                      Enumerable.Range(1, i)
                                .Reverse()));
    }    
