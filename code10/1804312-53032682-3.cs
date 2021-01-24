    List<ChocolateFactory> myChocos = new List<ChocolateFactory>();
    using (StreamReader sr = new StreamReader(@"e:\temp\input.txt"))
    {
        int lineCount = int.Parse(sr.ReadLine());
        while (!sr.EndOfStream)
        {
            string[] line = sr.ReadLine().Split(';');
            bool isPremium = line[line.Length - 1] == "premium";
            int length = isPremium ? line.Length - 1 : line.Length;
            var t = isPremium ? new PremiumChocolateFactory() 
                              : new ChocolateFactory();
            t.ChocolateType = line[0];
            t.CocoaAmount = Int32.Parse(line[1]);
            for (int i = 2; i < length; i++)
                t.Materials.Add(line[i]);
            myChocos.Add(t);
        }
    }
    ....
    foreach(var x in myChocos)
        Console.WriteLine(x);
