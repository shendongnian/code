    public interface ICustomTimer
    {
        string Value { get; set; }
    
        //Implementation in Timer
        void Start();
    
        //Implementation in Timer
        void Stop();
    }
    
    public class CustomTimer : System.Timers.Timer, ICustomTimer
    {
        public string Value { get; set; }
        void ICustomTimer.Start() { this.Start(); }
        void ICustomTimer.Stop() { this.Stop(); }
    }
