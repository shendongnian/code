    using System.Threading;
    public class AlarmClock
    {
        public int startTime = TimeOfDay.Hour;
        public int interval = 1;
        public event SoundAlarmEventHandler SoundAlarm;
        public delegate void SoundAlarmEventHandler();
        public void CheckTime()
        {
            while (TimeOfDay.Hour < startTime + interval) {
                Application.DoEvents();
            }
            if (SoundAlarm != null) {
                SoundAlarm();
            }
        }
        public void StartClock()
        {
            Thread clockthread = new Thread(CheckTime);
            clockthread.Start();
        }
    }
