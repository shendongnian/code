public static string LowerCaseFirstLetter(string value)
{
	if (value?.Length > 0)
	{
		var letters = value.ToCharArray();
		letters[0] = char.ToLowerInvariant(letters[0]);
		return new string(letters);
	}
	return value;
}
