            try
            {
                string str = (string) value;
                if ((culture != null) && !string.IsNullOrEmpty(str))
                {
                    str = ((string) value).Trim();
                    if ((!culture.IsNeutralCulture && (str.Length > 0)) && (culture.NumberFormat != null))
                    {
                        switch (culture.NumberFormat.PercentPositivePattern)
                        {
                            case 0:
                            case 1:
                                if ((str.Length - 1) == str.LastIndexOf(culture.NumberFormat.PercentSymbol, StringComparison.CurrentCultureIgnoreCase))
                                {
                                    str = str.Substring(0, str.Length - 1);
                                }
                                break;
    
                            case 2:
                                if (str.IndexOf(culture.NumberFormat.PercentSymbol, StringComparison.CurrentCultureIgnoreCase) == 0)
                                {
                                    str = str.Substring(1);
                                }
                                break;
                        }
                    }
                    num = Convert.ToDouble(str, culture);
                    flag = true;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
            }
            catch (ArgumentNullException)
            {
            }
            catch (FormatException)
            {
            }
            catch (OverflowException)
            {
            }
