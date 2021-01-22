public string RemoveMultiSpace(string test)
{
	var words = test.Split(new char[] { ' ' }, 
		StringSplitOptions.RemoveEmptyEntries);
	return string.Join(" ", words);
}
