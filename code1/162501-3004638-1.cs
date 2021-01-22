        public DateTime GetNextMonday()
        {
        
                DateTime dt = DateTime.Today;
                
                if dt.DayOfWeek == DayOfWeek.Monday
                {
                     dt.AddDays(7);
                }
                else
                {
                   while (dt.DayOfWeek != DayOfWeek.Monday)
                   {
                    dt = dt.AddDays(1);
                   }
                }
                return dt;
        }
