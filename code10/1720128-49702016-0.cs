    foreach (String line in lines)
    {
        String[] split = line.Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (split.Length == 3)
            Console.WriteLine("The line contains 3 values.");
        else
            Console.WriteLine("The line contains 2 values.");
    }
