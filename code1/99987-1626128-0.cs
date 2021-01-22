    public class MyStopWatchContext
    {
        Stopwatch _watch = new Stopwatch();
    
        public void OnMethodEntry()
        {
            _watch.Start();
        }
    
        public void OnMethodExit()
        {
            _watch.End();
            Debug.Print(_watch.Duration);
        }
    }
