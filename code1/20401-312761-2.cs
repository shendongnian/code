    public void Nonsense()
    {
        var letters = new[]{"A","B","C","D","E","F",
                            "G","H","I","J","K","L",
                            "M","N","O","P","Q","R","S",
                            "T","U","V","W","X","Y","Z"};
        foreach (var val in Sequence(letters, 4))
            Console.WriteLine(val);
    }
    private IQueryable<string> Sequence(string[] alphabet, int size)
    {
        // create the first level
        var sequence = alphabet.AsQueryable();
        // add each subsequent level
        for (var i = 1; i < size; i++)
            sequence = AddLevel(sequence, alphabet);
        return from value in sequence
               orderby value
               select value;
    }
    private IQueryable<string> AddLevel(IQueryable<string> current, string[] characters)
    {
        return from one in current
               from character in characters
               select one + character;
    }
