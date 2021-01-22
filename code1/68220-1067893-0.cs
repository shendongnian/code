        var data = new DbConnectionStringBuilder();
        data["foo"] = "abc";
        data["bar"] = "123 + ;la";
        string s = data.ConnectionString;
        byte[] raw = Encoding.UTF8.GetBytes(s);
        string alphaNumeric = Convert.ToBase64String(raw); // send this
        raw = Convert.FromBase64String(alphaNumeric);
        s = Encoding.UTF8.GetString(raw);
        data.ConnectionString = s;
        foreach (string key in data.Keys)
        {
            Console.WriteLine(key + "=" + data[key]);
        }
