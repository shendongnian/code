				string feed = ""; // input
				bool hadBOM = FixBOMIfNeeded(ref feed);
				var xElem = XElement.Parse(feed); // now does not fail
---
		/// <summary>
		/// You can get this or test it originally with: Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble())[0];
		/// But no need, this way we have a constant. As these three bytes `[239, 187, 191]` (a BOM) evaluate to a single C# char.
		/// </summary>
		public const char BOMChar = (char)65279;
		public static bool FixBOMIfNeeded(ref string str)
		{
			if (string.IsNullOrEmpty(str))
				return false;
			bool hasBom = str[0] == BOMChar;
			if (hasBom)
				str = str.Substring(1);
			return hasBom;
		}
