    private static DateTime ParseDateTime(string dateTime) {
        DateTime? d1 = null;
        try {
            d1 = DateTime.Parse(dateTime);
        }
        catch { }
        if (d1 == null) {
            try {
                d1 = DateTime.ParseExact(dateTime, "yyyyMMdd HH:mm:ss", CultureInfo.InvariantCulture);
            }
            catch { }
        }
        return (DateTime)d1;
    }
