    public static class Constants
    {
        // Use readonly static members
        public static readonly string
            ApproverlevelL1 = Level.Get("1"),
            ApproverlevelL2 = Level.Get("2"),
            ApproverlevelL3 = Level.Get("3"),
            ApproverlevelL4 = Level.Get("4"),
            ApproverlevelL5 = Level.Get("5");
        // Or you could use the latest convenient syntax
        public static string ApproverLevelL6 => Level.Get("6");
        // Or you could use readonly properties
        public static string ApproverLevelL7 { get { return Level.Get("7"); } }
    }
    public class Level
    {
        public static string Get(string levelId)
        {
            //... do logic
            return "";
        }
    }
