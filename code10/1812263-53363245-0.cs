    for (int i = 0; i < str.Length; i++)
    {
        var c = str[i];
        if (i == 0)
        {
            if (!(c == '+' || c == '-' || char.IsDigit(c)) {
                return false;
            }
        }
        if (!char.IsDigit(c)) return false;
    }
    return true;
