    public abstract class AbstractEasterBunny
    {
        /// <summary>
        /// Gets the Orthodox easter sunday for the requested year
        /// </summary>
        /// <param name="year">The year you want to know the Orthodox Easter Sunday of</param>
        /// <returns>DateTime of Orthodox Easter Sunday</returns>
        public abstract System.DateTime EasterSunday(int year);
        public abstract System.DateTime GoodFriday(int year);
        public static AbstractEasterBunny CreateInstance()
        {
            System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.CurrentCulture;
            System.Globalization.RegionInfo ri = new System.Globalization.RegionInfo(ci.LCID);
            
            // https://msdn.microsoft.com/en-us/library/windows/desktop/dd374073(v=vs.85).aspx
            System.Collections.Generic.List<int> lsOrthodox = new System.Collections.Generic.List<int>{
                 0x10D // Serbia and Montenegro
                ,0x10E // Montenegro
                ,0x10F // Serbia
                ,0x19 // Bosnia and Herzegovina
                // ,0x46 // Estonia
                // ,0x4B // Czech Republic
                // ,0x4D // Finland
                ,0x62 // Greece
                // ,0x6D // Hungary
                ,0x79 // Iraq
                // ,0x8C // Latvia
                // ,0x8D // Lithuania
                // ,0x8F // Slovakia
                // ,0x98 // Moldova
                // ,0xD4 // Slovenia
                ,0x4CA2 // Macedonia, Former Yugoslav Republic of
                ,0xEB // Turkey
            };
            // if(ci == WesternSlavonicOrthodox)
            if (lsOrthodox.Contains(ri.GeoId))
                return new OrthodoxEasterBunny();
            // TODO: Correct for Armenia/Georgia ? ? ? 
            // if(ri.GeoId == 0x7 || ri.GeoId == 0x58) // 0x7: Armenia, 0x58: Georgia
                // return new CatholicEasterBunny();
            
            // if(ci == EasternSlavonic)
            string strMonthName = ci.DateTimeFormat.GetMonthName(8);
            if (System.Text.RegularExpressions.Regex.IsMatch(strMonthName, @"\p{IsCyrillic}"))
            {
                // there is at least one cyrillic character in the string
                return new OrthodoxEasterBunny();
            }
            return new CatholicEasterBunny();
        }
    }
    public class OrthodoxEasterBunny : AbstractEasterBunny
    {
        /// <summary>
        /// Gets the Orthodox easter sunday for the requested year
        /// </summary>
        /// <param name="year">The year you want to know the Orthodox Easter Sunday of</param>
        /// <returns>DateTime of Orthodox Easter Sunday</returns>
        public override System.DateTime EasterSunday(int year)
        {
            int a = year % 19;
            int b = year % 7;
            int c = year % 4;
            int d = (19 * a + 16) % 30;
            int e = (2 * c + 4 * b + 6 * d) % 7;
            int f = (19 * a + 16) % 30;
            int key = f + e + 3;
            int month = (key > 30) ? 5 : 4;
            int day = (key > 30) ? key - 30 : key;
            return new System.DateTime(year, month, day);
        }
        public override System.DateTime GoodFriday(int year)
        {
            return this.EasterSunday(year).AddDays(-2);
        }
    }
    public class CatholicEasterBunny : AbstractEasterBunny
    {
        /// <summary>
        /// Gets the Catholic easter sunday for the requested year
        /// </summary>
        /// <param name="year">The year you want to know the Catholic Easter Sunday of</param>
        /// <returns>DateTime of Catholic Easter Sunday</returns>
        public override System.DateTime EasterSunday(int year)
        {
            int day = 0;
            int month = 0;
            int g = year % 19;
            int c = year / 100;
            int h = (c - (int)(c / 4) - (int)((8 * c + 13) / 25) + 19 * g + 15) % 30;
            int i = h - (int)(h / 28) * (1 - (int)(h / 28) * (int)(29 / (h + 1)) * (int)((21 - g) / 11));
            day = i - ((year + (int)(year / 4) + i + 2 - c + (int)(c / 4)) % 7) + 28;
            month = 3;
            if (day > 31)
            {
                month++;
                day -= 31;
            }
            return new System.DateTime(year, month, day);
        }
        public override System.DateTime GoodFriday(int year)
        {
            return this.EasterSunday(year).AddDays(-2);
        }
    }
