    public static Type getTypeFromString(String s)
            {
                if (s.Length == 1)
                    if (new Regex(@"[^0-9]").IsMatch(s)) return Type.GetType("System.Char");
                else
                    return Type.GetType("System.Byte", true, true);
    
                if (new Regex(@"^(\+|-)?\d+$").IsMatch(s))
                {
                    Decimal d;
                    if (Decimal.TryParse(s, out d))
                    {
                        if (d <= Byte.MaxValue && d >= Byte.MinValue) return Type.GetType("System.Byte", true, true);
                        if (d <= UInt16.MaxValue && d >= UInt16.MinValue) return Type.GetType("System.UInt16", true, true);
                        if (d <= UInt32.MaxValue && d >= UInt32.MinValue) return Type.GetType("System.UInt32", true, true);
                        if (d <= UInt64.MaxValue && d >= UInt64.MinValue) return Type.GetType("System.UInt64", true, true);
                        if (d <= Decimal.MaxValue && d >= Decimal.MinValue) return Type.GetType("System.Decimal", true, true);
                    }
                }
    
                if (new Regex(@"^(\+|-)?\d+[" + NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator + @"]\d*$").IsMatch(s))
                {
                    Double d;
                    if (Double.TryParse(s, out d))
                    {
                        if (d <= Single.MaxValue && d >= Single.MinValue) return Type.GetType("System.Single", true, true);
                        if (d <= Double.MaxValue && d >= Double.MinValue) return Type.GetType("System.Double", true, true);
                    }
                }
                
                if(s.Equals("true",StringComparison.InvariantCultureIgnoreCase) || s.Equals("false",StringComparison.InvariantCultureIgnoreCase))
                    return Type.GetType("System.Boolean", true, true);
    
                DateTime dateTime;
                if(DateTime.TryParse(s, out dateTime))
                    return Type.GetType("System.DateTime", true, true); 
    
                return Type.GetType("System.String", true, true); 
            }
