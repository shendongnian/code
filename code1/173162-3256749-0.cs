    const int C = 10000;
    int[] ids = new int[C];
    string[] names = new string[C];
    Stopwatch sw = new Stopwatch();
    sw.Start();
    for (int i = 0; i< C; i++)
    {
        var id = (i % 50) + 1;
        names[i] = ((States)id).ToString();
    }
	sw.Stop();
    Console.WriteLine("Enum: " + sw.Elapsed.TotalMilliseconds);
    var namesById = Enum.GetValues(typeof(States)).Cast<States>()
                    .ToDictionary(s => (int) s, s => s.ToString());
    sw.Restart();
    for (int i = 0; i< C; i++)
    {
        var id = (i % 50) + 1;
        names[i] = namesById[id];
    }
	sw.Stop();
    Console.WriteLine("Dictionary: " + sw.Elapsed.TotalMilliseconds);
