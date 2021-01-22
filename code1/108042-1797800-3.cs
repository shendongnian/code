    public class SystemTimeMachine : TimeMachine
    {
        public override DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }
    }
