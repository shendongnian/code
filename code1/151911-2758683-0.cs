    private static readonly SortedList<int, string> _registeredScriptIncludes = new SortedList<int, string>();
		public static void RegisterScriptInclude(this HtmlHelper htmlhelper, string script)
		{
			if (!_registeredScriptIncludes.ContainsValue(script))
			{
				_registeredScriptIncludes.Add(_registeredScriptIncludes.Count, script);
			}
		}
		public static string RenderScript(this HtmlHelper htmlhelper, string script)
		{
			var scripts = new StringBuilder();
			scripts.AppendLine("<script src='" + script + "' type='text/javascript'></script>");
			return scripts.ToString();
		}
		public static string RenderScripts(this HtmlHelper htmlhelper)
		{
			var scripts = new StringBuilder();
			scripts.AppendLine("<!-- Rendering registered script includes -->");
			foreach (string script in _registeredScriptIncludes.Values)
			{
				scripts.AppendLine("<script src='" + script + "' type='text/javascript'></script>");
			}
			return scripts.ToString();
		}
