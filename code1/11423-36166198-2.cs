    private string PhoneNumberFormatter(string value)
    {
        value = new Regex(@"\D").Replace(value, string.Empty);
        value = value.TrimStart('1');
        if (value.Length > 0 & value.Length < 4)
        {
            value = string.Format("({0})", value.Substring(0, value.Length));
            return value;
        }
        if (value.Length > 3 & value.Length < 7)
        {
            value = string.Format("({0}) {1}", value.Substring(0, 3), value.Substring(3, value.Length - 3));
            return value;
        }
        if (value.Length > 6 & value.Length < 11)
        {
            value = string.Format("({0}) {1}-{2}", value.Substring(0, 3), value.Substring(3, 3), value.Substring(6));
            return value;
        }
        if (value.Length > 10)
        {
            value = value.Remove(value.Length - 1, 1);
            value = string.Format("({0}) {1}-{2}", value.Substring(0, 3), value.Substring(3, 3), value.Substring(6));
            return value;
        }
        return value;
    }
