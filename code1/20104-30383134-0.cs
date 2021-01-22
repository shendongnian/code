    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace LT
    {
        public static class Utility
        {
            static string invalidRegStr;
    
            public static string MakeValidFileName(this string name)
            {
                if (invalidRegStr == null)
                {
                    var invalidChars = System.Text.RegularExpressions.Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
                    invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);
                }
    
                return System.Text.RegularExpressions.Regex.Replace(name, invalidRegStr, "_");
            }
        }
    }
