    foreach (string text in source)
    {
        string textLocal = text; // this is all you need to add
        testThreads.Add(new Thread(() =>
        {
            Console.WriteLine(textLocal); // well, and change this line
        }));
    }
