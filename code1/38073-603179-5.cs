    using System;
    using System.Configuration;
    namespace MyProjectNamespace {
        public class DirectoryInfoConfigSection : ConfigurationSection {
            [ConfigurationProperty("Directory")]
            public DirectoryConfigElement Directory {
                get {
                    return (DirectoryConfigElement)base["DirectoryInfo"];
                }
        }
        public class DirectoryConfigElement : ConfigurationElement {
            [ConfigurationProperty("MyBaseDir")]
            public String BaseDirectory {
                get {
                    return (String)base["MyBaseDir"];
                }
            }
            [ConfigurationProperty("Dir1")]
            public String Dir1 {
                get {
                    return (String)base["Dir1"];
                }
            }
            [ConfigurationProperty("Dir2")]
            public String Dir2 {
                get {
                    return (String)base["Dir2"];
                }
            }
            // You can make custom properties to combine your directory names.
            public String Dir1Resolved {
                get {
                    return System.IO.Path.Combine(MyBaseDir, Dir1);
                }
            }
        }
    }
