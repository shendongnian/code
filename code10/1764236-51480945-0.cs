    if(File.Exists(newPath))
    {
        double[] test = File.ReadLines(newPath).Select(x => double.Parse(x)).ToArray()
        foreach(double number in test)
        {
            Console.WriteLine(number);
        }         
        Console.ReadLine();
    }
