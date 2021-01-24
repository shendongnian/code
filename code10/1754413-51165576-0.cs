    var result1 = string.Empty;
                int Count = 0;
                var str = objYardData.CAPACITY;
                var pat = "KT$";
                if (Regex.IsMatch(str, pat))
                {
                    var patt1 = "\\d+";
    
                    result1 = Regex.Match(str, patt1).Value;
                    Count = (Convert.ToInt32(result1) * 1000);
                    result1 = Count .ToString() + " T";
                }
                else
                {
                    result1 = objYardData.CAPACITY;
                }
