    const int InsertCount = 150000;
    var startTime = DateTime.Now;
    var ropeOfChars = new BigList<char>();
    for (int i = 0; i < InsertCount; i++)
    {
        ropeOfChars.Insert(0, (char)('a' + (i % 10)));
    }
    Console.WriteLine("Rope<char> time: {0}", DateTime.Now - startTime);
    startTime = DateTime.Now;
    var stringBuilder = new StringBuilder();
    for (int i = 0; i < InsertCount; i++)
    {
        stringBuilder.Insert(0, (char)('a' + (i % 10)));
    }
    Console.WriteLine("StringBuilder time: {0}", DateTime.Now - startTime);
