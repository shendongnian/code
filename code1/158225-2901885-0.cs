	public string GetAppGUID(string sectionId)
	{
		string hexString = null;
		int i = 0;
		int guidlen = 0;
		guidlen = 16;
		if (sectionId.Length < guidlen) {
			sectionId = sectionId + new string(" ".Chars(0), guidlen - sectionId.Length);
		}
		for (i = 1; i <= guidlen; i++) {
			hexString = hexString + Conversion.Hex(Strings.Asc(Strings.Mid(sectionId, i, 1)));
		}
		return hexString;
	}
