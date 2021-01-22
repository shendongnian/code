    // works only in WPF!
	public static bool CheckIfStringIsValidVarName(string stringToCheck)
	{
		if (string.IsNullOrWhiteSpace(stringToCheck))
			return false;
		TextBox textBox = new TextBox();
		try
		{
			// stringToCheck == ""; // !!! does NOT throw !!!
			// stringToCheck == "Name$"; // throws
			// stringToCheck == "0"; // throws
			// stringToCheck == "name with blank"; // throws
			// stringToCheck == "public"; // does NOT throw
			// stringToCheck == "ValidName";
			textBox.Name = stringToCheck;
		}
		catch (ArgumentException ex)
		{
			return false;
		}
		return true;
	}
