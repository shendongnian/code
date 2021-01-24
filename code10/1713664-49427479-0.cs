    using System;
    using System.Collections.Generic;
    using System.Configuration;
    
    namespace SSPWAS.Utilities
    {
        public static class Constants
        {
            public static readonly string
                ApproverlevelL1 = GetLevel("1"),
                ApproverlevelL2 = GetLevel("2"),
                ApproverlevelL3 = GetLevel("3"),
                ApproverlevelL4 = GetLevel("4"),
                ApproverlevelL5 = GetLevel("5");
    
            private static string GetLevel(string levelId)
            {
                //... do logic
                return "";
            }
        }
    }
