        string str = "‘";
        var encoding = System.Text.Encoding.Default;
        var values = encoding.GetBytes(str);
        Decimal dec = values[0];
        var hex = ToHexString(dec);
        string result = hex.ToString();
