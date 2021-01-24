    using System;
    using System.Collections.Generic;
    using System.Configuration;
    
    namespace SSPWAS.Utilities
    {
        public static class Constants
        {
            // Use readonly static members
            public static readonly string
                ApproverlevelL1 = GetLevel("1"),
                ApproverlevelL2 = GetLevel("2"),
                ApproverlevelL3 = GetLevel("3"),
                ApproverlevelL4 = GetLevel("4"),
                ApproverlevelL5 = GetLevel("5");
    
            // Or you could use the latest convenient syntax
            public static string ApproverLevelL6 => GetLevel("6");
    
            // Or you could use readonly properties
            public static string ApproverLevelL7 { get { return GetLevel("7"); } }
    
            private static string GetLevel(string levelId)
            {
                //... do logic
                return "";
            }
        }
    }
