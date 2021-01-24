Dictionary<string, Contact> data = new Dictionary<string, Contact>();
    foreach (var line in File.ReadAllLines(fileName).Where(l => !string.IsNullOrWhiteSpace(l)))
    {
        if (lineNum >= 4)
            break;
        string line = lines[lineNum];
        for (int i = 0; i < line.Length; )
        {
            string key = line.Substring(i, 4);
            string hexText = line.Substring(i, 9);
            int length = Convert.ToInt16(hexText.Substring(hexText.Length - 2), 16);
            string value = line.Substring(i + 9, length);
            if (lineNum == 3)
                value = FromUnixTime(Convert.ToInt64(value)).ToString();
            if (data.ContainsKey(key))
            {
                data[key].ContactSp.Add(value);
            }
            else
            {
                Contact c = new Contact();
                c.ContactSp.Add(value);
                data.Add(key, c);
            }
            i = i + 9 + length;
        }
    }
