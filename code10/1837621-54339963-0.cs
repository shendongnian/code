    int ctr = 0;
    string sentance = "The quick brown fox jumped over the lazy dog. ";
    string[] split = sentance.Split(new char[] { ' ', '.' });
    
    foreach (string s in split)
    {
        if (!string.IsNullOrWhiteSpace(s))
            Console.WriteLine("{0} {1}", ctr++, s);
    }
    Console.ReadLine();
