    public class AlarmClock
    {
        private ITime DateTime;
        public AlarmClock(ITime dateTime, int numberOfHours)
        {
            DateTime = dateTime;
            SetTime = DateTime.UtcNow.AddHours(numberOfHours);
            Task.Run(() =>
            {
                while (!IsAlarmOn)
                {
                    IsAlarmOn = (SetTime - DateTime.UtcNow).TotalMilliseconds < 0;
                }
            });
        }
        public DateTime SetTime { get; set; }
        public bool IsAlarmOn { get; set; }
    }
    [TestMethod]
    public void it_can_be_injected_as_a_dependency()
    {
        //virtual time has to be 1000*3.75 faster to get to an hour 
        //in 1000 ms real time
        var dateTime = DateTime.Now.ToVirtualTime(1000 * 3.75);
        var numberOfHoursBeforeAlarmSounds = 1;
        var alarmClock = new AlarmClock(dateTime, numberOfHoursBeforeAlarmSounds);
        Assert.IsFalse(alarmClock.IsAlarmOn);
        System.Threading.Thread.Sleep(1000);
        Assert.IsTrue(alarmClock.IsAlarmOn);
    }
