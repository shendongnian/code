    int counter = 0;
    foreach (string s in File.ReadAllLines(FileName))
    {
        ++counter;
        if (counter > 50?)
        {
            Console.WriteLine(s);
        }
    }
