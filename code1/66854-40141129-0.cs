                // Calculate departure date
                TimeSpan DeliveryTime = new TimeSpan(14, 30, 0); 
                TimeSpan now = DateTime.Now.TimeOfDay;
                DateTime dt = DateTime.Now;
                if (dt.TimeOfDay > DeliveryTime) dt = dt.AddDays(1);
                if (dt.DayOfWeek == DayOfWeek.Saturday) dt = dt.AddDays(1);
                if (dt.DayOfWeek == DayOfWeek.Sunday) dt = dt.AddDays(1);
                dt = dt.Date + DeliveryTime;
                string DepartureDay = "today at "+dt.ToString("HH:mm");
                if (dt.Day!=DateTime.Now.Day)
                {
                    DepartureDay = dt.ToString("dddd at HH:mm", new CultureInfo(WebContextState.CurrentUICulture));
                }
                Return DepartureDay;
                // Caclulate delivery date
                dt = dt.AddDays(1);
                if (dt.DayOfWeek == DayOfWeek.Saturday) dt = dt.AddDays(1);
                if (dt.DayOfWeek == DayOfWeek.Sunday) dt = dt.AddDays(1);
                string DeliveryDay = dt.ToString("dddd", new CultureInfo(WebContextState.CurrentUICulture));
                return DeliveryDay;
