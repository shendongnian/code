    public static double? GetDoubleFromString(string strNum)
            {
                double num = 0;
                strNum = strNum.Replace(',', '.');
    
                if (double.TryParse(strNum, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out num))
                    return num;
    
                return null;
            }
