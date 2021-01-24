    public static void foobar(string given, int number)
        {
            foreach (char c in given.Distinct())
            {
                if (given.Count(ch => c == ch) >= number) given = given.Replace(c.ToString(),"");
            }
        }
