    public static bool TryParseInt32(this string input, Action<int> action)
    {
        int result;
        if (Int32.TryParse(input, out result))
        {
            action(result);
            return true;
        }
        return false;
    }
