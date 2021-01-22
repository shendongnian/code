     String value = null;
            try
            {
                foreach (Char item in Registry.GetValue(registryKey, key, "").ToString().ToCharArray())
                {
                    if (Char.GetUnicodeCategory(item) != System.Globalization.UnicodeCategory.OtherLetter && Char.GetUnicodeCategory(item) != System.Globalization.UnicodeCategory.OtherNotAssigned)
                    {
                        value += item;
                    }
                }
            }
            catch (Exception ex)
            {
                LOG.Error("Unable to get value of " + key + ex, ex);
            }
            return value;
