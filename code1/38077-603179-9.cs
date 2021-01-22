    using System;
    using System.Configuration;
    namespace MyProjectNamespace {
        public class DirectoryInfoConfigSection : ConfigurationSection {
            [ConfigurationProperty("Directory")]
            public DirectoryConfigElement Directory {
                get {
                    return (DirectoryConfigElement)base["Directory"];
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
            public String Directory1 {
                get {
                    return (String)base["Dir1"];
                }
            }
            [ConfigurationProperty("Dir2")]
            public String Directory2 {
                get {
                    return (String)base["Dir2"];
                }
            }
            // You can make custom properties to combine your directory names.
            public String Directory1Resolved {
                get {
                    return System.IO.Path.Combine(BaseDirectory, Directory1);
                }
            }
        }
    }
