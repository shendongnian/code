    using System;
    using System.Collections.Generic;
    using System.Configuration;
    namespace SSPWAS.Utilities
    {
        public class Constants
        {
            public static Func<string, string> getLevel = x => string.Empty;
            // added get accessor to make these read only
            public static string ApproverlevelL1 { get; } = getLevel("1");
            public static string ApproverlevelL2 { get; } = getLevel("2");
            public static string ApproverlevelL3 { get; } = getLevel("3");
            public static string ApproverlevelL4 { get; } = getLevel("4");
            public static string ApproverlevelL5 { get; } = getLevel("5");
        }
        public class WhateverClass
        {
            public string getLevel(string levelID)
            {
                string levelName;
                //logic here
                return levelName; 
            }
            // call this before accessing the fields in your Constants class
            public void Init()
            {
                Constants.getLevel = x => getLevel(x);
            }
        }
    }
