        private Instantiate()
        {
            BrowserQueue = new ConcurrentQueue<BrowserAction>();
            BrowserThread = new Thread(new ThreadStart(BrowserThreadLoop));
            BrowserThread.SetApartmentState(ApartmentState.STA);
            BrowserThread.Name = "BrowserThread";
            BrowserThread.Start();
        }
        private static void BrowserThreadLoop()
        {
            while (true)
            {
                Thread.Sleep(500);
                BrowserAction act = null;
                while (Instance.BrowserQueue.TryDequeue(out act))
                {
                    try
                    {
                        act.Action();
                    }
                    catch (Exception ex) { }
                    finally
                    {
                        act.CompletionToken.Set();
                    }
                }
            }
        }
        public static void RunBrowserAction(Action act)
        {
            BrowserAction ba = new BrowserAction() { Action = act, CompletionToken = new ManualResetEvent(false) };
            Instance.BrowserQueue.Enqueue(ba);
            ba.CompletionToken.WaitOne();
        }
        public class BrowserAction
        {
            public Action Action { get; set; } = null;
            public ManualResetEvent CompletionToken { get; set; } = null;
        }
        ConcurrentQueue<BrowserAction> BrowserQueue;
