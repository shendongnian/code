    public bool ValidateWeekend(DateTime pickupDate, DateTime dropoffDate){
        TimeSpan ts = dropoffDate.Subtract(pickupDate);
        if (ts.TotalDays >= 2 && ts.TotalDays <= 4){
            switch (pickupDate.DayOfWeek){
                case DayOfWeek.Thursday:
                    if (pickupDate.Hour >= 12){
                        switch (dropoffDate.DayOfWeek){
                            case DayOfWeek.Sunday:
                                return true;
                            case DayOfWeek.Monday:
                                return dropoffDate.Hour <= 12;
                        }
                    }
                    break;
                case DayOfWeek.Friday:
                    switch (dropoffDate.DayOfWeek){
                        case DayOfWeek.Sunday:
                            return true;
                        case DayOfWeek.Monday:
                            return dropoffDate.Hour <= 12;
                    }
                    break;
                case DayOfWeek.Saturday:
                    switch (dropoffDate.DayOfWeek){
                        case DayOfWeek.Sunday:
                            return true;
                        case DayOfWeek.Monday:
                            return dropoffDate.Hour <= 12;
                    }
                    return false;
            }
        }
        return false;
    }
