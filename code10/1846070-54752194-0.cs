	public static class XmlFormatting {
		static readonly string sNewLineComment = new XComment($"x-newline-placeholder-{Guid.NewGuid()}").ToString();
		static readonly Regex sNewLineCommentRegex = new Regex($@"^\s*{sNewLineComment}\s*$", RegexOptions.Compiled | RegexOptions.Multiline);
		static readonly Regex sEmptyLineRegex = new Regex(@"^\s*$", RegexOptions.Compiled | RegexOptions.Multiline);
		public static string PrettyPrintXml(string inputXml) {
			string newlinesReplacedWithComments = sEmptyLineRegex.Replace(inputXml, sNewLineComment);
			string formattedDocument = XDocument.Parse(newlinesReplacedWithComments, LoadOptions.None).ToString();
			return sNewLineCommentRegex.Replace(formattedDocument, string.Empty);
		}
	}
