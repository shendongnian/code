	public static int GetAge( DateTime dob, DateTime today, out int days, out int months ) {
            DateTime dt = today;
            if( dt.Day < dob.Day ) {
                dt = dt.AddMonths( -1 );
            }
            months = dt.Month - dob.Month;
            if( months < 0 ) {
                dt = dt.AddYears( -1 );
                months += 12;
            }
            int years = dt.Year - dob.Year;
            var offs = dob.AddMonths( years * 12 + months );
            days = (int)( ( today.Ticks - offs.Ticks ) / TimeSpan.TicksPerDay );
            return years;
        }
