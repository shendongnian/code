    public static string foobar(string given, int number)
    {
        string result = given;
        foreach (char c in result.Distinct())
        {
            if (given.Count(ch => c == ch) >= number) result= result.Replace(c.ToString(),"");
        }
        return result;
    }
