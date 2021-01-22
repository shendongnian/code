    if (ts.TotalDays >= 2 && ts.TotalDays <= 4)
            {
                switch (pickupDate.DayOfWeek)
                {
                    case DayOfWeek.Thursday:
                    case DayOfWeek.Friday:
                    case DayOfWeek.Saturday:
                        if (pickupDate.DayOfWeek == DayOfWeek.Thursday && pickupDate.Hour <= 12)
                            return false;
                        switch (dropoffDate.DayOfWeek)
                        {
                            case DayOfWeek.Sunday:
                                return true;
                            case DayOfWeek.Monday:
                                return dropoffDate.Hour <= 12;
                        }
                        return false;
                    default:
                        return false;
                }
            }
            return false;
