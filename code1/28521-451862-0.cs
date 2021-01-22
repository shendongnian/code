    String str = "Last, First <name@domain.com>, name@domain.com, First Last <name@domain.com>, \"First Last\" <name@domain.com>";
    List<string> addresses = new List<string>();
    int atIdx = 0;
    int commaIdx = 0;
    int lastComma = 0;
    for (int c = 0; c < str.Length; c++)
    {
    if (str[c] == '@')
        atIdx = c;
    if (str[c] == ',')
        commaIdx = c;
    if (commaIdx > atIdx && atIdx > 0)
    {
        string temp = str.Substring(lastComma, commaIdx - lastComma);
        addresses.Add(temp);
        lastComma = commaIdx;
        atIdx = commaIdx;
    }
    if (c == str.Length -1)
    {
        string temp = str.Substring(lastComma, str.Legth - lastComma);
        addresses.Add(temp);
    }
    }
    if (commaIdx < 2)
    {
        // if we get here we can assume either there was no comma, or there was only one comma as part of the last, first combo
        addresses.Add(str);
    }
