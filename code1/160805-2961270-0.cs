    enum AlarmTypes
    {
        Heartbeat,
        AnotherAlarm,
        // ...
    }
    delegate void CreateTriggerDelegate();
    class Alarm
    {
        // ...
        public CreateTriggerDelegate CreateTriggerFunction { get; set; }
    }
    class HeartbeatAlarm : Alarm
    {
        // ...
        public static HeartbeatAlarm GetAlarm()
        {
            return new HeartbeatAlarm();
        }
    }
    class QuartzAlarmScheduler
    {
        public static CreateTriggerDelegate CreateMinutelyTrigger { get; set; }
    }
    class AlarmFactory
    {
        public static Alarm GetAlarm(AlarmTypes alarmType)  //factory ensures that correct alarm is returned and right func pointer for trigger creator.
        {
            switch (alarmType)
            {
                case AlarmTypes.Heartbeat:
                    return GetHeartbeatAlarm();
                default:
                    throw new ArgumentException("Unrecognized AlarmType: " + alarmType.ToString(), "alarmType");
            }
        }
        static Alarm _GetAlarm<T>()
            where T : Alarm
        {
            Type type = typeof(T);
            if (type.Equals(typeof(HeartbeatAlarm)))
                return GetHeartbeatAlarm();
            else
                throw new ArgumentException("Unrecognized generic Alarm argument: " + type.FullName, "T");
        }
        public static T GetAlarm<T>()
            where T : Alarm
        {
            return (T)_GetAlarm<T>();
        }
        public static HeartbeatAlarm GetHeartbeatAlarm()
        {
            HeartbeatAlarm alarm = HeartbeatAlarm.GetAlarm();
            alarm.CreateTriggerFunction = QuartzAlarmScheduler.CreateMinutelyTrigger;
            return alarm;
        }
    }
    class Example
    {
        static void GetAlarmExamples()
        {
            HeartbeatAlarm alarm;
            
            alarm = AlarmFactory.GetHeartbeatAlarm();
            alarm = AlarmFactory.GetAlarm<HeartbeatAlarm>();
            alarm = (HeartbeatAlarm)AlarmFactory.GetAlarm(AlarmTypes.Heartbeat);
        }
    }
