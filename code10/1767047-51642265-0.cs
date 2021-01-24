    public void PrintLengthIfString(object obj)
    {
        if (obj is string)
        {
            string str = (string) obj;
            Console.WriteLine(str.Length);
        }
    }
