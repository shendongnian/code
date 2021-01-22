    private static void OriginalCode(IEnumerable<long> elements)
    {
        foreach (int element in elements)
        {
            Console.WriteLine(element);
        }
    }
    
    private static void TranslatedCode(IEnumerable<long> elements)
    {
        int element;
        IEnumerator<long> tmp1 = elements.GetEnumerator();
    
        try
        {
            while (tmp1.MoveNext())
            {
                element = (int)tmp1.Current;
                Console.WriteLine(element);
            }
        }
        finally
        {
            (tmp1 as IDisposable).Dispose();
        }
    }
