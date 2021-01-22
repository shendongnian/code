    using System;
    using System.Text;
    
    public static class ExtensionLibrary
    {
        public static void AppendFormattedLine(this StringBuilder sb, string format, object arg0)
        {
            sb.AppendFormat(format, arg0).Append(Environment.NewLine);
        }
        public static void AppendFormattedLine(this StringBuilder sb, string format, object arg0, object arg1)
        {
            sb.AppendFormat(format, arg0, arg1).Append(Environment.NewLine);
        }
        public static void AppendFormattedLine(this StringBuilder sb, string format, object arg0, object arg1, object arg2)
        {
            sb.AppendFormat(format, arg0, arg1, arg2).Append(Environment.NewLine);
        }
        public static void AppendFormattedLine(this StringBuilder sb, string format, params object[] args)
        {
            sb.AppendFormat(format, args).Append(Environment.NewLine);
        }
    }
