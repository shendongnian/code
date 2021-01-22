    List<string> SplitString(int chunk, string input)
    {
        List<string> list = new List<string>();
        int cycles = input.Length / chunk;
        if (input.Length % chunk != 0)
            cycles++;
        for (int i = 0; i < cycles; i++)
        {
            try
            {
                list.Add(input.Substring(i * chunk, chunk));
            }
            catch
            {
                list.Add(input.Substring(i * chunk));
            }
        }
        return list;
    }
