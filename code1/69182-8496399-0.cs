        public int getMonths(DateTime startDate, DateTime endDate)
        {
            int months = 0;
        
            if (endDate.Month <= startDate.Month)
            {
                if (endDate.Day < startDate.Day)
                {
                    months = (12 * (endDate.Year - startDate.Year - 1))
                           + (12 - startDate.Month + endDate.Month - 1);
                }
                else if (endDate.Month < startDate.Month)
                {
                    months = (12 * (endDate.Year - startDate.Year - 1))
                           + (12 - startDate.Month + endDate.Month);
                }
                else  // (endDate.Month == startDate.Month) && (endDate.Day >= startDate.Day)
                {
                    months = (12 * (endDate.Year - startDate.Year));
                }
            }
            else if (endDate.Day < startDate.Day)
            {
                months = (12 * (endDate.Year - startDate.Year))
                       + (endDate.Month - startDate.Month) - 1;
            }
            else  // (endDate.Month > startDate.Month) && (endDate.Day >= startDate.Day)
            {
                months = (12 * (endDate.Year - startDate.Year))
                       + (endDate.Month - startDate.Month);
            }
            return months;
        }
