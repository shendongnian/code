    public interface IAlarm
    {
        public int bpm { get; set; }    // declared base props
    }
    public class Alarm : IAlarm
    {
        public int bpm { get; set; }    // implemented base props
    }
    public class HeartbeatAlarm : Alarm
    {
        public int min { get; set; }    // extended type specific props
    }
    public class FactoryMethods
    {
        public static T AlarmFactory<T>(int bpm) where T : IAlarm, new()
        {
            // interfaces have no constructor but you can do this
            T alarm = new T() {
                bpm = bpm
            };
            return alarm;
        }
    }
    // C# will automagically infer the type now..
    HeartbeatAlarm heartbeatAlarm = FactoryMethods.AlarmFactory<HeartbeatAlarm>(40);
