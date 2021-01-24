    using System;
    using System.Collections.Generic;
    using System.Configuration;
    
    namespace SSPWAS.Utilities
    {
        public static class Constants
        {
            public static string ApproverlevelL1 = getLevel("1");
            public static string ApproverlevelL2 = getLevel("2");
            public static string ApproverlevelL3 = getLevel("3");
            public static string ApproverlevelL4 = getLevel("4");
            public static string ApproverlevelL5 = getLevel("5");
            private static string getLevel(string levelID)
    		{
    			string levelName;
    			logic here
    			return levelName; 
    		}
        }
    }
