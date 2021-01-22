    private static void OriginalCode(long[] elements)
    {
        foreach (int element in elements)
        {
            Console.WriteLine(element);
        }
    }
    
    private static void TranslatedCode(long[] elements)
    {
        int element;
        long[] tmp1 = elements;
        int tmp2 = 0;
    
        if (tmp2 < elements.Length)
        {
            // the cast avoids an error
            element = (int)elements[tmp2++];
            Console.WriteLine(element);
        }
    }
