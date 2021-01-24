    public static string ToProperDate(this string input)
    {
       DateTime d = DateTime.Parse(input);
       return String.Format("{0:dddd, MMMM d, yyyy}", d);
    }
