    internal string GetFormattedString()
    {
        switch (JsonType)
        {
            case JsonType.String:
                if (_value is string || _value == null)
                {
                    return (string)_value;
                }
                if (_value is char)
                {
                    return _value.ToString();
                }
                throw new NotImplementedException(SR.Format(SR.NotImplemented_GetFormattedString, _value.GetType()));
            case JsonType.Number:
                string s = _value is float || _value is double ?
                    ((IFormattable)_value).ToString("R", NumberFormatInfo.InvariantInfo) : // Use "round-trip" format
                    ((IFormattable)_value).ToString("G", NumberFormatInfo.InvariantInfo);
                return s == "NaN" || s == "Infinity" || s == "-Infinity" ?
                    "\"" + s + "\"" :
                    s;
            default:
                throw new InvalidOperationException();
        }
    }
