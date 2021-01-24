Dictionary<string, Contact> data = new Dictionary<string, Contact>();
    foreach (var line in File.ReadAllLines(fileName).Where(l =!string.IsNullOrWhiteSpace(l)))
    {
        for(int i = 0; i < line.Length; )
        {
            string key = line.Substring(i, 4);
            string hexText = line.Substring(i, 9);
            int length = 0;
            if(!int.TryParse(hexText.Substring(hexText.Length - 2), out length))
            {
                length = 10;
            }
                    
            string value = line.Substring(i + 9, length);
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
