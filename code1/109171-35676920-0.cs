    var dates = new List<DateTime>();
            
            for (var dt = YourStartDate; dt <= YourEndDate; dt = dt.AddDays(1))
            {
                if (dt.DayOfWeek != DayOfWeek.Sunday && dt.DayOfWeek != DayOfWeek.Saturday)
                { dates.Add(dt); }
                
            }
