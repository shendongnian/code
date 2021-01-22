    static void Main(string[] args)
    {
        const string filename = @"data.txt";
        bool first = true;
        int min=0, max=0, total=0;
        var lines = File.ReadAllLines(filename);
        foreach (var line in lines)
        {
            var score = int.Parse(line.Trim());
            if (first)
            {
                min = max = total = score;
                first = false;
                continue;
            }
            if (score < min)
                min = score;
            if (score > max)
                max = score;
            total += score;
        }
        
        if (first)
        {
            Console.WriteLine("no input");
            return;
        }
        var average = (double)total/lines.Length;
        Console.WriteLine(string.Format("Min: {0}, Max: {1}, Average: {2:F2}", min, max, average));
    }
