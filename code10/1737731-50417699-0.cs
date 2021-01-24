    public class ScheduleStudyTimeComparer : IEqualityComparer<ScheduleStudyTime>
    {
        public bool Equals(ScheduleStudyTime x, ScheduleStudyTime y)
        {
            // TODO: Check for nulls and possibly make the decision using
            // other properties as well
            return x.STUDTIME_ID  == y.STUDTIME_ID ;
        }
    
        public int GetHashCode(ScheduleStudyTime obj)
        {
            return obj.ScheduleStudyTime.GetHashCode();
        }
    }
