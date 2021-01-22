    string camelCase = "HelloWorld";
    StringBuilder sb = new StringBuilder();
    sb.Append(camelCase[0]);
    for (int i = 1; i < camelCase.Length; i++)
	{
        int charValue = Convert.ToInt16(camelCase[i]);
        if (charValue > 64 && charValue < 91)
        {
            sb.Append(" ");
        }
        sb.Append(camelCase[i]);
	}
    string withSpaces = sb.ToString();
