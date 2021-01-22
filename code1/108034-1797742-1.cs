    private bool IsPickupWeekend(DateTime pickupDate)
    {
        switch (pickupDate.DayOfWeek)
                {
                    case DayOfWeek.Thursday:
                        return pickupDate.Hour >= 12;
                    case DayOfWeek.Friday:                    
                    case DayOfWeek.Saturday:
                        return true;
                }
            }
            return false;
    }
    private bool IsWeekendDropOff(DateTime dropoffDate)
    {
        switch (dropoffDate.DayOfWeek)
                        {
                            case DayOfWeek.Sunday:
                                return true;
                            case DayOfWeek.Monday:
                                if (dropoffDate.Hour <= 12)
                                {
                                    return true;
                                }
                                return false;
                        }
                        return false;
    
    }
