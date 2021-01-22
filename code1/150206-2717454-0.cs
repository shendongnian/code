    for(int i = 0; i < list.Length; i++)
    {
        string val;
        list[i] = list[i]++;
        val = list[i].ToString();
        Console.WriteLine(val);
    }
