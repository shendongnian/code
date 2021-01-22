    public class FormatProvider : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof (ICustomFormatter))
            {
                return this;
            }
            return null;
        }
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null || arg.GetType() != typeof (double))
            {
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(string.Format("The format of '{0}' is invalid.", format));
                }
            }
            if (format.StartsWith("T"))
            {
                int dp = 2;
                int idx = 1;
                if (format.Length > 1)
                {
                    if (format[1] == '(')
                    {
                        int closeIdx = format.IndexOf(')');
                        if (closeIdx > 0)
                        {
                            if (int.TryParse(format.Substring(2, closeIdx - 2), out dp))
                            {
                                idx = closeIdx + 1;
                            }
                        }
                        else
                        {
                            throw new FormatException(string.Format("The format of '{0}' is invalid.", format));
                        }
                    }
                }
                double mult = Math.Pow(10, dp);
                arg = Math.Truncate((double)arg * mult) / mult;
                format = format.Substring(idx);
            }
            try
            {
                return HandleOtherFormats(format, arg);
            }
            catch (FormatException e)
            {
                throw new FormatException(string.Format("The format of '{0}' is invalid.", format));
            }
        }
        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
            {
                return ((IFormattable) arg).ToString(format, CultureInfo.CurrentCulture);
            }
            return arg != null ? arg.ToString() : String.Empty;
        }
    }
