    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Drawing;
    namespace ConfigTest
    { [ Serializable() ]
    
        public class ConfigManager
        {
            private string windowTitle = "Corp";
            private string printTitle = "Inventory";
    
        public string WindowTitle
        {
                get
                {
                    return windowTitle;
                }
                set
                {
                    windowTitle = value;
                }
            }
    
        public string PrintTitle
        {
                get
                {
                    return printTitle;
                }
                set
                {
                    printTitle = value;
                }
        }
       }
    }
