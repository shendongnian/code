        public static string TwoLetterSuffix(this DateTime @this)
        {
            var dayMod10 = @this.Day % 10;
            if (dayMod10 > 3 || dayMod10 == 0 || (@this.Day >= 10 && @this.Day <= 19))
            {
                return "th";
            }
            else if(dayMod10 == 1)
            {
                return "st";
            }
            else if (dayMod10 == 2)
            {
                return "nd";
            }
            else
            {
                return "rd";
            }
        }
