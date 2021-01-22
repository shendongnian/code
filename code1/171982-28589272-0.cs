    static public List<string> get_days_between_two_dates(DateTime start_date, DateTime end_date)
        {
            List<string> days_list = new List<string>();
            DateTime temp_start;
            DateTime temp_end;
    
            //--Normalize dates by getting rid of minues since they will get in the way when doing the loop
            temp_start = new DateTime(start_date.Year, start_date.Month, start_date.Day);
            temp_end = new DateTime(end_date.Year, end_date.Month, end_date.Day);
    
            //--Example Should return
            //--1-12-2014 5:59AM - 1-13-2014 6:01AM return 12 and 13
            for (DateTime date = temp_start; date <= temp_end; date = date.AddDays(1))
            {
                days_list.Add(date.ToShortDateString());
            }
    
            return days_list;
        }
