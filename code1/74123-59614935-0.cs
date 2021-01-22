    public static string FirstPartOfPostcode(this string str)
		{
			string postCodeNoSpaces = str.Replace(" ", "");
			char lastDigit = postCodeNoSpaces[postCodeNoSpaces.Length - 3];
			if(postCodeNoSpaces.All(char.IsDigit) || !Char.IsDigit(lastDigit))
			{
				throw new ArgumentException("Invalid PostCode");
			}
			string firstPart = postCodeNoSpaces.Substring(0, postCodeNoSpaces.Length - 3);
			return firstPart;
		}
