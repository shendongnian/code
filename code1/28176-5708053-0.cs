    		public static class WebControlsExtensions
			{
				public static void AddCssClass(WebControl control, string cssClass)
				{
					string[] cssClasses = control.CssClass.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
					List<string> classes = new List<string>(cssClasses);
					if (!classes.Contains(cssClass)) {
						classes.Add(cssClass);
					}
					control.CssClass = StringExtensions.ToDelimitedString(classes, " ");
				}
				public static void RemoveCssClass(WebControl control, string cssClass)
				{
					string[] cssClasses = control.CssClass.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
					List<string> classes = new List<string>(cssClasses);
					bool removed = true;
					while (removed) {
						removed = classes.Remove(cssClass);
					}
					control.CssClass = StringExtensions.ToDelimitedString(classes, " ");
				}
		}
		static class StringExtensions {
			public static string ToDelimitedString(List<string> list, string delimiter)
			{
				StringBuilder sb = new StringBuilder();
				foreach (string item in list) {
					if (sb.Length > 0)
						sb.Append(delimiter);
					sb.Append(item);
				}
				return sb.ToString();
			}
		}
