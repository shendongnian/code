    public static string GetItemByIndex(string line, int index)
    {
        for (var i = 0; i < line.Length; i++)
        {
            if (index == 0)
            {
                for (int j = i; j < line.Length; j++)
                {
                    if (line[j] == ',')
                    {
                        return line.Substring(i, j - i);
                    }
                }
                return line.Substring(i, line.Length - i);
            }
            if (line[i] == ',' && index != 0)
            {
                index--;
            }
        }
        return null;
    }
