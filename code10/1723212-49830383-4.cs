    public static class CSharpControlChars
    {
        public static readonly string NewLine = Environment.NewLine;
        public static string CrLf => $"{Cr}{Lf}";
        public const char Cr = '\r';
        public const char Lf = '\n';
        public const char FormFeed = '\f';
        public const char Null = '\0';
        public const char BackSpace = '\b';
        public const char Tab = '\t';
        public const char VertTab = '\v';
    }
