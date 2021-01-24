    for (int i = 0; i < nameChar.Count; i++)
    {
        if (nameChar[i] == 'o')
        {
            // After removing the element at index i,
            // we want to try index i again, so decrement
            // and continue without printing.
            nameChar.Remove(nameChar[i]);
            i--;
            continue;
        }
        Console.Write(nameChar[i]);
    }
