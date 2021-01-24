    public class WaitForActionProcess : IProcess
    {
        public Action Finished { get; set; }
        Action<Action> Subscribe { get; }
        Action<Action> Unsubscribe { get; }
        public WaitForActionProcess(Action<Action> subscribe, Action<Action> unsubscribe)
        {
            Subscribe = subscribe;
            Unsubscribe = unsubscribe;
        }
        public void Play()
        {
            Subscribe(RaiseFinished);
        }
        public void RaiseFinished()
        {
            Unsubscribe(RaiseFinished);
            Finished?.Invoke();
        }
    }
