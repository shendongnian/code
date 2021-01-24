            object[] result = this.ExtensionGet("my-custom-date");
            if (result != null && result.Length > 0)
            {
                if (result[0].GetType() == typeof(string))
                {
                    long l = 0;
                    return (long.TryParse(result[0].ToString(), out l) ? DateTime.FromFileTimeUtc(l) : (DateTime?)null);
                }
                else
                {
                    ActiveDs.IADsLargeInteger li = (ActiveDs.IADsLargeInteger)result[0];
                    return DateTime.FromFileTimeUtc(((long)li.HighPart << 32) + li.LowPart).ToLocalTime();
                }
            }
            else
                return null;
        }
        set
        {
            if (value != null)
                ExtensionSet("my-custom-date", ((DateTime)value).ToFileTimeUtc().ToString());
            else
                ExtensionSet("my-custom-date", null);
        }
    }
