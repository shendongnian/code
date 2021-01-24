    public class Schedule {
        public Schedule(
            //...
            ScheduleType scheduleType
            //...
            ) {
            //...
            ScheduleType = scheduleType;
        }
        //...
        public ScheduleType ScheduleType { get; set; }
        public bool IsFixed {
            get {
                return ScheduleType != null && ScheduleType.HasFlag(ScheduleType.Fixed);
            }
        }
        public bool IsFlexible {
            get {
                return
                    ScheduleType != null && ScheduleType.HasFlag(ScheduleType.Flexible);
            }
        }
        public bool IsFullTime {
            get {
                return
                    ScheduleType != null && ScheduleType.HasFlag(ScheduleType.FullTime);
            }
        }
        //...
    }
