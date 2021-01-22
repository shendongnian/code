      public static string Change_to_date_yymmdd(DateTime dt)
        {
            //string strTest = stringTest();
            string format = "yyMMdd";
            string date = dt.ToString(format, DateTimeFormatInfo.InvariantInfo);
            return date;
        }
        public static string Change_to_time_24hr60min60sec60ms(DateTime dt)
        {
            string format = "HHmmssff";
            string time = dt.ToString(format, DateTimeFormatInfo.InvariantInfo);
            return time;
        }
        public static string Change_to_rangevalidator(DateTime dt)
        {
            //string strTest = stringTest();
            string format = "yyyy-MM-dd-HH-mm-ss";
            string date = dt.ToString(format, DateTimeFormatInfo.InvariantInfo);
            return date;
        }
