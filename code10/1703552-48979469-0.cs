    var changed = Regex.Replace(str, @"[a-zA-z]",
        delegate (Match c) {
            if (c.Value == "z" || c.Value == "Z")
            {
                return "A";
            }
            else
            {
                return Convert.ToChar(Convert.ToInt32(c)).ToString();
            }
        });
