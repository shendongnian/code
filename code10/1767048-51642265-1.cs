    public void PrintLengthIfString(object obj)
    {
        if (obj is string str)
        {
            // No cast here, it's in the pattern match!
            Console.WriteLine(str.Length);
        }
    }
