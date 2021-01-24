        public class Private
        {
            internal bool enabled = true;
            public class CamShield
            {
                enabled = false;
                public static void start()
                {
                    new Thread(() =>
                    {
                        Thread.CurrentThread.IsBackground = true;                        
                        Timer camShieldTimer = new Timer(tap, null, 0, 20000);
                    }).Start();
                }
            }
    
            internal static void tap(Object o)
            {
                enabled = true;
                AdbClient.Instance.ExecuteRemoteCommand("input tap 600 900", Device.lookup(), null);
                Debug.WriteLine("Tapped");
            }
        }
