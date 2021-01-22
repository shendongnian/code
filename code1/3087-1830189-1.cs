    public static System.DateTime getstartweek()
        {
            System.DateTime dt = System.DateTime.Now;
            System.DayOfWeek dmon = System.DayOfWeek.Monday;
            int span = dt.DayOfWeek - dmon;
            dt = dt.AddDays(-span);
            return dt;
        }
