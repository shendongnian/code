    foreach (int i = 0; i < values.Length; i++)
    {
        SqlParameter param = insertCmd.Parameters[i];
        if (string.IsNullOrEmpty(values[i]))
        {
            param.Value = new Decimal(0m);
        }
        else
        {
            decimal d = new Decimal(0m);
            if (decimal.TryParse(values[i], out d))
                param.Value = d;
            else
                param.Value = new Decimal(0m);
        }   
    }
