        public DateTime RoundToMinutes(DateTime dt, int NrMinutes)
        {
            long TicksInNrMinutes = (long)NrMinutes * 60 * 10000000;//1 tick per 100 nanosecond
            long ticks = dt.Ticks + TicksInNrMinutes / 2;
            return new DateTime(ticks - ticks % TicksInNrMinutes, dt.Kind);
        }
