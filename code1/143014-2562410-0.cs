    public interface ITimeEvent
    {
        ITimeEventHandler Handler { get; set; }
    }
    public interface IJobTimeEvent : ITimeEvent
    {
        int JobID { get; set; }
    }
    public class JobTimeEvent : IJobTimeEvent
    {
        public JobTimeEvent()
        {
            //these are currently useless because they are the default values
            this.JobID = 0;
            this.Handler = null;
        }
        public int JobID { get; set; }
        public ITimeEventHandler Handler { get; set; }
    }
