		/// <summary>
		/// Find controls
		/// </summary>
		/// <param name="c">Control</param>
		/// <param name="predicate">Function</param>
		/// <returns>Control's</returns>
		public static IEnumerable<Control> FindRecursive(Control c, Func<Control, bool> predicate)
		{
			if (predicate(c))
			{
				yield return c;
			}
			foreach (Control child in c.Controls)
			{
				foreach (Control founded in FindRecursive(child, predicate))
				{
					yield return founded;
				}
			}
		}
		/// <summary>
		/// Find WebControls by attr
		/// </summary>
		/// <param name="c">Control</param>
		/// <returns>WebControls</returns>
		public static IEnumerable<WebControl> FindWebControlsByAttr(Control baseControl, string attrName, string attrValue)
		{
			foreach (WebControl c in FindRecursive(baseControl, c => (c is WebControl)
				&& !string.IsNullOrEmpty(((WebControl)c).Attributes[attrName])
				&& ((WebControl)c).Attributes[attrName].Contains(attrValue)))
			{
				yield return c;
			}
		}
		/// <summary>
		/// Find HtmlGenericControls by attr
		/// </summary>
		/// <param name="c">Control</param>
		/// <returns>HtmlGenericControls</returns>
		public static IEnumerable<HtmlGenericControl> FindControlsByAttr(Control baseControl, string attrName, string attrValue)
		{
			foreach (HtmlGenericControl c in FindRecursive(baseControl, c => (c is HtmlGenericControl)
				&& !string.IsNullOrEmpty(((HtmlGenericControl)c).Attributes[attrName])
				&& ((HtmlGenericControl)c).Attributes[attrName].Contains(attrValue)))
			{
				yield return c;
			}
		}
