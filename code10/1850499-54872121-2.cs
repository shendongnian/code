    public static class TimeSpanExtension {
        const decimal TicksPerNanosecond = TimeSpan.TicksPerMillisecond / 1000000m;
        public static decimal GetTotalNanoSeconds(this TimeSpan ts) => ts.Ticks / TicksPerNanosecond;
        public static decimal GetNanoSeconds(this TimeSpan ts) => ts.Ticks % TimeSpan.TicksPerMillisecond / TicksPerNanosecond;
    }
