    public static string FormatWith(this string format, object source)
    {
        StringBuilder sbResult = new StringBuilder(format.Length);
        StringBuilder sbCurrentTerm = new StringBuilder();
        char[] formatChars = format.ToCharArray();
        bool inTerm = false;
        object currentPropValue = source;
        for (int i = 0; i < format.Length; i++)
        {
            if (formatChars[i] == '{')
                inTerm = true;
            else if (formatChars[i] == '}')
            {
                PropertyInfo pi = currentPropValue.GetType().GetProperty(sbCurrentTerm.ToString());
                sbResult.Append((string)(pi.PropertyType.GetMethod("ToString", new Type[]{}).Invoke(pi.GetValue(currentPropValue, null), null)));
                sbCurrentTerm.Clear();
                inTerm = false;
                currentPropValue = source;
            }
            else if (inTerm)
            {
                if (formatChars[i] == '.')
                {
                    PropertyInfo pi = currentPropValue.GetType().GetProperty(sbCurrentTerm.ToString());
                    currentPropValue = pi.GetValue(source, null);
                    sbCurrentTerm.Clear();
                }
                else
                    sbCurrentTerm.Append(formatChars[i]);
            }
            else
                sbResult.Append(formatChars[i]);
        }
        return sbResult.ToString();
    } 
