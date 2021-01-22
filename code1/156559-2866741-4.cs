    public class Delayer
    {
        private System.Threading.Timer _timer;
        
        private void Delay(Action action, Int32 ms)
        {
            if (ms <= 0)
            {
                action();
            }
            _timer = new System.Threading.Timer(
                (o) => action(), 
                null, 
                ms, 
                System.Threading.Timeout.Infinite);
        }
    }
