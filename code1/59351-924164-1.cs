    static string GetColumnName(int index)
    {
        const int alphabetsCount = 26;
        string result = string.Empty;
        while (index > 0) {
            result = char.ConvertFromUtf32(64 + (index % alphabetsCount)) + result;
            index /= alphabetsCount;
        }
        return result;
    }
