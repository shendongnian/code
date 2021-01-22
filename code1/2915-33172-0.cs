	public class CsvParser
	{
		public char FieldDelimiter { get; set; }
		public CsvParser()
			: this(',')
		{
		}
		public CsvParser(char fieldDelimiter)
		{
			FieldDelimiter = fieldDelimiter;
		}
		public IEnumerable<IEnumerable<string>> Parse(string text)
		{
			return Parse(new StringReader(text));
		}
		public IEnumerable<IEnumerable<string>> Parse(TextReader reader)
		{
			while (reader.Peek() != -1)
				yield return parseLine(reader);
		}
		IEnumerable<string> parseLine(TextReader reader)
		{
			bool insideQuotes = false;
			StringBuilder item = new StringBuilder();
			while (reader.Peek() != -1)
			{
				char ch = (char)reader.Read();
				char? nextCh = reader.Peek() > -1 ? (char)reader.Peek() : (char?)null;
				if (!insideQuotes && ch == FieldDelimiter)
				{
					yield return item.ToString();
					item.Length = 0;
				}
				else if (!insideQuotes && ch == '\r' && nextCh == '\n') //CRLF
				{
					reader.Read(); // skip LF
					break;
				}
				else if (!insideQuotes && ch == '\n') //LF for *nix-style line endings
					break;
				else if (ch == '"' && nextCh == '"') // escaped quotes ""
				{
					item.Append('"');
					reader.Read(); // skip next "
				}
				else if (ch == '"')
					insideQuotes = !insideQuotes;
				else
					item.Append(ch);
			}
			// last one
			yield return item.ToString();
		}
	}
