    public static class DecimalToTimeConverters
    {
        public static DateTime ToDateTime(this decimal value)
        {
            string[] parts = value.ToString().Split(new char[] { '.' });
    
            int hours = Convert.ToInt32(parts[0]);
            int minutes = Convert.ToInt32(parts[1]);
    
            if ((hours > 23) || (hours < 0))
            {
                throw new ArgumentOutOfRangeException("value", "decimal value must be no greater than 23.59 and no less than 0");
            }
            if ((minutes > 59) || (minutes < 0))
            {
                throw new ArgumentOutOfRangeException("value", "decimal value must be no greater than 23.59 and no less than 0");
            }
            DateTime d = new DateTime(1, 1, 1, hours, minutes, 0);
            return d;
        }
    
        public static Decimal ToDecimal(this DateTime datetime)
        {
            Decimal d = new decimal();
            d = datetime.Hour;
            d = d + Convert.ToDecimal((datetime.Minute * 0.01));
    
            return d;
        }
    }
