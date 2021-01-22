    static void Example()
    {
        int i = 0;
    top:
        Console.WriteLine(i.ToString());
        if (i == 0)
        {
            i++;
            goto top;
        }
    }
