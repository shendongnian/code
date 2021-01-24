        public class Private
        {
            public class CamShield
            {
                internal bool enabled = true;
    
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
                AdbClient.Instance.ExecuteRemoteCommand("input tap 600 900", Device.lookup(), null);
                Debug.WriteLine("Tapped");
            }
        }
