    public static List<string> MatchFlags<T> (T matchThis) where T : struct
    {
        if (!(matchThis is System.Enum)) {
            thrown new ArgumentException("Gotta be an enum");
        }
        //etc.
    }
