            TimeSpan ts = Convert.ToDateTime("02:00 PM").TimeOfDay;
            TimeSpan checkValue1 = Convert.ToDateTime("01:00 PM").TimeOfDay;
            TimeSpan checkValue2 = Convert.ToDateTime("03:00 PM").TimeOfDay;
            bool passed = (ts >= checkValue1 && ts <= checkValue2);
            
