    using System;
    using System.Text.RegularExpressions;
    public static class MyExtensions {
		public static string ReplaceIgnoreCase(this string search, string find, string replace) {
			return Regex.Replace(search ?? "", Regex.Escape(find ?? ""), (replace ?? "").Replace("$", "$$"), RegexOptions.IgnoreCase);			
		}
	}
