    namespace SSPWAS.Utilities
    {
        public class Constants
        {
            public static string getLevel(string levelID)
            {
                string levelName;
                //logic here
                return levelName; 
            }
            // added get accessor to make these read only
            public static string ApproverlevelL1 { get; } = getLevel("1");
            public static string ApproverlevelL2 { get; } = getLevel("2");
            public static string ApproverlevelL3 { get; } = getLevel("3");
            public static string ApproverlevelL4 { get; } = getLevel("4");
            public static string ApproverlevelL5 { get; } = getLevel("5");
        }
    }
