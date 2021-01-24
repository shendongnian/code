    public static string ConvertCultureCurrencyToString(string stringValue, CultureInfo ci)
        {
            try
            {
                if (string.IsNullOrEmpty(stringValue))
                    return "0";
                stringValue = System.Convert.ToString(stringValue, ci);
                // currency -> double (format to double)
                var currency = decimal.Parse(stringValue, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, ci);
                stringValue = currency.ToString("#,###.###", ci);
                return stringValue;
            }
            catch
            {
                return "0";
            }
        }
