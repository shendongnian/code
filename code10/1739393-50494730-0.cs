    public static DateTime Round(this DateTime dt, TimeSpan rnd) {
        if (rnd == TimeSpan.Zero)
            return dt;
        else {
            var ansTicks = dt.Ticks + rnd.Ticks / 2;
            return new DateTime(ansTicks - ansTicks % rnd.Ticks);
        }
    }
