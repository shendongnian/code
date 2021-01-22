    public static class MyResources
    {
        [WantThis]
        public static string TOKEN_ONE { get { return "One"; } }
        [WantThis]
        public static string TOKEN_TWO { get { return "Two"; } }
        public static string DontWantThis { get { return "Nope"; } }
    }
