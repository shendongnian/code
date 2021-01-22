    using System;
    using System.Text;
    
    namespace ParseSPListItemXML
    {
		public static class ExtensionLibrary
		{
			public static void AppendFormattedLine(this StringBuilder sb, string format, params object[] args)
			{
				sb.AppendFormat(format, args).Append(Environment.NewLine);
			}
		}
    }
