		/// <summary>
		/// A list of XElement descendent elements with the supplied local name (ignoring any namespace), or null if the element is not found.
		/// </summary>
		public static IEnumerable<XElement> FindDescendants(this XElement likeThis, string elementName) {
			var result = likeThis.Descendants().Where(ele=>ele.Name.LocalName==elementName);
			return result;
		}
