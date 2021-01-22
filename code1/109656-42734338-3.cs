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
					sb.Append(char.ConvertFromUtf32(charCodeLength)); //Handle characters above 2^16 by converting them to a surrogate pair
					i += 2 + charCodeLength;
				}
				else if (char.GetUnicodeCategory(str, i) == UnicodeCategory.Format)
				{
					//Use (string, index) in order to handle surrogate pairs
					//Skip this character
					if (char.IsSurrogatePair(str, i)) i += 2;
					else i += 1;
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
			if (!IsValidParsedIdentifierStart(str, 0)) return false;
			int firstCharWidth = char.IsSurrogatePair(str, 0) ? 2 : 1;
			for (int i = firstCharWidth; i < str.Length; ) //Manual increment
			{
				if (!IsValidParsedIdentifierPart(str, i)) return false;
				if (char.IsSurrogatePair(str, i)) i += 2;
				else i += 1;
			}
			return true;
		}
		//(String, index) pairs are used instead of chars in order to support surrogate pairs
		//(Unicode code-points above 2^16 represented using two 16-bit characters)
		public static bool IsValidParsedIdentifierStart(string s, int index)
		{
			return s[index] == '_' || char.IsLetter(s, index) || char.GetUnicodeCategory(s, index) == UnicodeCategory.LetterNumber;
		}
		
		public static bool IsValidParsedIdentifierPart(string s, int index)
		{
			if (s[index] == '_' || (s[index] >= '0' && s[index] <= '9') || char.IsLetter(s, index)) return true;
			switch (char.GetUnicodeCategory(s, index))
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
