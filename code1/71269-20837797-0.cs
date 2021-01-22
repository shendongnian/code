    using MMLib.RapidPrototyping.Generators;
    public void WordGeneratorExample()
    {
       WordGenerator generator = new WordGenerator();
       var randomWord = generator.Next();
       Console.WriteLine(randomWord);
    } 
