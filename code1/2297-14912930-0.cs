	void Main() {
		string content = "\v\f\0";
		Console.WriteLine(IsValidXmlString(content)); \\False
		
		content = RemoveInvalidXmlChars(content);
		Console.WriteLine(IsValidXmlString(content)); \\True
	}
	
	static string RemoveInvalidXmlChars(string text) {
		var validXmlChars = text.Where(ch => XmlConvert.IsXmlChar(ch)).ToArray();
		return new string(validXmlChars);
	}
	
	static bool IsValidXmlString(string text) {
		try {
			XmlConvert.VerifyXmlChars(text);
			return true;
		} catch {
			return false;
		}
	}
