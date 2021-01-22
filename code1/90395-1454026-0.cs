	string dataUS = "Lo: 46°F. Hi: 67°F. Chance of precipitation: 20%";
	string dataDE = "Niedrig: 46°F. Höchst: 67°F. Niederschlag %: 20%";
	string[] stringValues = dataU.Split(new string[] {": "}, 4, StringSplitOptions.None);
	List<int> values = new List<int>();
	for (int i = 1; i < 4; i++)
	{
		StringBuilder sb = new StringBuilder();
		foreach (char c in stringValues[i].Trim())
		{
			if (Char.IsDigit(c))
			{
				sb.Append(c);
			}
			else
			{
				values.Add(Convert.ToInt32(sb.ToString()));
				break;
			}
		}
	}
