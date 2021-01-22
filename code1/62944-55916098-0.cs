        /// <summary>
        /// This lets you compare two dates (dd/MM/yyyy) - the first against the second - 
        /// returning an integer specifying the relation between the two.
        /// If 1, then the first date is greater than the second; 
        /// if 0, then the first date is equal to the second; 
        /// if -1, then the first date is less than the second.
        /// </summary>
        /// <param name="Date1">The first date in string format: dd/MM/yyyy</param>
        /// <param name="Date2">The second date in string format: dd/MM/yyyy</param>
        /// <returns>
        /// 1 : The first date is greater than the second. 
        /// 0 : The first date is equal to the second. 
        /// -1 : The first date is less than the second.
        /// </returns>
        public int CompareDates(string Date1, string Date2)
        {
            try
            {
                string separator_value = "/";
                string[] date1_parts = Date1.Split(separator_value.ToCharArray());
                string[] date2_parts = Date2.Split(separator_value.ToCharArray());
                // 0 : Day
                // 1 : Month
                // 2 : Year
                if (string.CompareOrdinal(date1_parts[2], date2_parts[2]) > 0)
                {
                    return 1;
                }
                else if (date1_parts[2] == date2_parts[2])
                {
                    if (string.CompareOrdinal(date1_parts[1], date2_parts[1]) > 0)
                    {
                        return 1;
                    }
                    else if (date1_parts[1] == date2_parts[1])
                    {
                        if (string.CompareOrdinal(date1_parts[0], date2_parts[0]) > 0)
                        {
                            return 1;
                        }
                        else if (date1_parts[0] == date2_parts[0])
                        {
                            return 0;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }
