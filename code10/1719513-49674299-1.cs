    public static class Extensions
    {
        public static string[] CustomSplit(this string toSplit, char delimiter, string emptyEntities) => 
            toSplit.Split(delimiter).Select(c => c == string.Empty ? emptyEntities : c).ToArray();
    }
