    public static class SlotExtensions
    {
        public static List<Slot> GetInactive(this List<Slot> slots)
        {
            Slot day = new Slot
            {
                StartTime = new TimeSpan(0,0,0),
                EndTime = new TimeSpan(24,0,0)
            }
            List<Slot> inactive = new List<Slot>();
            Slot tmp;
            foreach(Slot slot in slots)
            {
                if(day.StartTime < slot.StartTime)
                {
                    tmp = new Slot
                    {
                        StartTime = day.StartTime;
                        EndTime = slot.StartTime;
                    };
                    inactive.Add(tmp);
                };
                day.StartTime = slot.EndTime;
            }
            if(day.StartTime < day.EndTime)
            {
                inactive.Add(day);
            }
            return inactive;
        }
    }
