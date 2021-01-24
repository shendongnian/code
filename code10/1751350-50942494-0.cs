    var result = list.OrderBy(GetFirstCyrillicIndex).ThenBy(x => x).ToList();
    ...
    private static int GetFirstCyrillicIndex(string text)
    {
        // This could be written using LINQ, but it's probably simpler this way.
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] >= 0x400 && text[i] <= 0x4ff)
            {
                return i;
            }
        }
        return int.MaxValue;
    }
