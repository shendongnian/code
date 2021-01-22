    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace EmbeddedWebServer
    {
        internal class StringHelpers
        {
    
    
    
            public static bool Contains(string source, string value)
            {
                if (source == null || value == null)
                    return false;
    
                return System.Globalization.CultureInfo.InvariantCulture.CompareInfo.IndexOf(source, value, System.Globalization.CompareOptions.IgnoreCase) != -1;
            }
    
    
        }
    }
