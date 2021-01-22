    public static IEnumerable<String> LastToFirstOrSomething(String s)
    {
        String[] parts = s.Split(';');
        String result = String.Empty;
        for (Int32 index = parts.Length - 1; index >= 0; index--)
        {
            if (result.Length > 0)
                result = ";" + result;
            result = parts[index] + result;
            yield return result;
        }
    }
