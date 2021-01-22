    using System;
    using System.Text;
    
    namespace ParseSPListItemXML
    {
        public static class ExtensionLibrary
        {
            public static void AppendFormattedLine(this StringBuilder sb,  string format,  object arg0)
            {
                sb.AppendFormat("{0}{1}", string.Format(format, arg0), Environment.NewLine);
            }  
            public static void AppendFormattedLine(this StringBuilder sb, string format, object arg0, object arg1)
            {
                sb.AppendFormat("{0}{1}", string.Format(format, arg0, arg1), Environment.NewLine);
            }
            public static void AppendFormattedLine(this StringBuilder sb, string format, object arg0, object arg1, object arg2)
            {
                sb.AppendFormat("{0}{1}", string.Format(format, arg0, arg1, arg2), Environment.NewLine);
            }
            public static void AppendFormattedLine(this StringBuilder sb, string format, object[] args)
            {
                sb.AppendFormat("{0}{1}", string.Format(format, args), Environment.NewLine);
            }
        }
    }
