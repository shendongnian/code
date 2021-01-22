	public static class CSharpIdentifiers
	{
		private static HashSet<string> _keywords = new HashSet<string> {
			"abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked",
			"class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else",
			"enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for",
			"foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock",
			"long", "namespace", "new", "null", "object", "operator", "out", "override", "params",
			"private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed",
			"short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw",
			"true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using",
			"virtual", "void", "volatile", "while"
		};
		public static ICollection<string> Keywords { get { return _keywords; } }
		public static bool TryParseRawIdentifier(string str, out string parsed)
		{
			if (string.IsNullOrEmpty(str) || _keywords.Contains(str)) { parsed = null; return false; }
			StringBuilder sb = new StringBuilder(str.Length);
			int verbatimCharWidth = str[0] == '@' ? 1 : 0;
			for (int i = verbatimCharWidth; i < str.Length; ) //Manual increment
			{
				char c = str[i];
				if (c == '\\')
				{
					char next = str[i + 1];
					int charCodeLength;
					if (next == 'u') charCodeLength = 4;
					else if (next == 'U') charCodeLength = 8;
					else { parsed = null; return false; }
					//No need to check for escaped backslashes or special sequences like \n,
					//as they not valid identifier characters
					int charCode;
					if (!TryParseHex(str.Substring(i + 2, charCodeLength), out charCode)) { parsed = null; return false; }
					sb.Append((char)charCodeLength);
					i += 2 + charCodeLength;
				}
				else if (char.GetUnicodeCategory(c) == UnicodeCategory.Format)
				{
					//Skip this character
				}
				else
				{
					sb.Append(c);
					i++;
				}
			}
			parsed = sb.ToString();
			return true;
		}
		private static bool TryParseHex(string str, out int result)
		{
			return int.TryParse(str, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out result);
			//NumberStyles.AllowHexSpecifier forces all characters to be hex digits
		}
		public static bool IsValidParsedIdentifier(string str)
		{
			if (string.IsNullOrEmpty(str)) return false;
			if (!IsValidParsedIdentifierStart(str[0])) return false;
			for (int i = 1; i < str.Length; i++) {
				if (!IsValidParsedIdentifierPart(str[i])) return false;
			}
			return true;
		}
		public static bool IsValidParsedIdentifierStart(char c)
		{
			return c == '_' || char.IsLetter(c) || char.GetUnicodeCategory(c) == UnicodeCategory.LetterNumber;
		}
		
		public static bool IsValidParsedIdentifierPart(char c)
		{
			if (c == '_' || (c >= '0' && c <= '9') || char.IsLetter(c)) return true;
			switch (char.GetUnicodeCategory(c))
			{
				case UnicodeCategory.LetterNumber: //Eg. Special Roman numeral characters (not covered by IsLetter())
				case UnicodeCategory.DecimalDigitNumber: //Includes decimal digits in other cultures
				case UnicodeCategory.ConnectorPunctuation:
				case UnicodeCategory.NonSpacingMark:
				case UnicodeCategory.SpacingCombiningMark:
				//UnicodeCategory.Format handled in TryParseRawIdentifier()
					return true;
				default:
					return false;
			}
		}
	}
