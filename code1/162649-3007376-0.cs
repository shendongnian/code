    IEnumerable<string> magicCounter()
    {
        // 0000, 0001, ..., 9999
        for (int i = 0; i < 10000; ++i)
        {
            yield return i.ToString().PadLeft(4, '0');
        }
        // A000, A001, ..., Z999
        for (char c = 'A'; c <= 'Z'; ++c)
        {
            for (int i = 0; i < 1000; ++i)
            {
                yield return c + i.ToString().PadLeft(3, '0');
            }
        }
    }
