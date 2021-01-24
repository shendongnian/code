                public static (decimal price, int nights) GetPrice
            (DateTime arrivalDate, DateTime departureDate)
        {
            //This code assumes there is no time component in the dates provided 
            if(departureDate < arrivalDate )
            {
                throw new ArgumentException("Arrival after Departure");
            }
            if (departureDate.Date == arrivalDate.Date)
            {
                //TODO
                return (0, 0);
            }
            Decimal totalPrice = 0;
            DateTime day = arrivalDate;
            while (day != departureDate)
            {
                totalPrice += GetRate(day.DayOfWeek);
                day = day.AddDays(1);
            }
            return (totalPrice, (int)(departureDate - arrivalDate).TotalDays);
        }
        private static decimal GetRate(DayOfWeek dow)
        {
            return (dow == DayOfWeek.Friday || dow == DayOfWeek.Saturday)
                ? 150
                : 120;
        }
