    private async Task<long> DoASync(string v, string filename)
    {
        string lines;
        long counter = 0;
        using (StreamReader file = new StreamReader(filename))
        {
            lines = await reader.ReadToEndAsync();
        }
        Console.WriteLine($"{v}: T{Thread.CurrentThread.ManagedThreadId}: Lines: {lines.Split('\n').Length}");
        return counter;
    }
