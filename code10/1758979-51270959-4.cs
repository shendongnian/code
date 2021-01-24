    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var callReceiver = new CallReceiver();
            var thread = new Thread(callReceiver.WaitForCall);
            thread.Start();
            
            Application.Run(new Form1(callReceiver));
        }
    }
    public class CallReceiver
    {
        public event EventHandler<int> CallReceived;
        
        public void WaitForCall()
        {
            var i = 0;
            while (true)
            {
                Thread.Sleep(1000);
                OnCallReceived(i++);//Dummy event emitter
            }
        }
        protected virtual void OnCallReceived(int e)
        {
            CallReceived?.Invoke(this, e);
        }
    }
