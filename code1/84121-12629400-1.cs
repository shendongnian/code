		/// <summary>
		/// Produce an XPath literal equal to the value if possible; if not, produce
		/// an XPath expression that will match the value.
		/// 
		/// Note that this function will produce very long XPath expressions if a value
		/// contains a long run of double quotes.
		/// 
		/// From: http://stackoverflow.com/questions/1341847/special-character-in-xpath-query
		/// </summary>
		/// <param name="value">The value to match.</param>
		/// <returns>If the value contains only single or double quotes, an XPath
		/// literal equal to the value.  If it contains both, an XPath expression,
		/// using concat(), that evaluates to the value.</returns>
		public static string XPathLiteral(string value)
		{
			// If the value contains only single or double quotes, construct
			// an XPath literal
			if (!value.Contains("\""))
				return "\"" + value + "\"";
			if (!value.Contains("'"))
				return "'" + value + "'";
			// If the value contains both single and double quotes, construct an
			// expression that concatenates all non-double-quote substrings with
			// the quotes, e.g.:
			//
			//    concat("foo",'"',"bar")
			List<string> parts = new List<string>();
			// First, put a '"' after each component in the string.
			foreach (var str in value.Split('"'))
			{
				if (!string.IsNullOrEmpty(str))
					parts.Add('"' + str + '"'); // (edited -- thanks Daniel :-)
				parts.Add("'\"'");
			}
			// Then remove the extra '"' after the last component.
			parts.RemoveAt(parts.Count - 1);
			// Finally, put it together into a concat() function call.
			return "concat(" + string.Join(",", parts) + ")";
		}
