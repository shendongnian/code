        public class CamShield
        {
            internal bool enabled = false;
            public void start()
            {
                if(!enabled)
                {
                    enabled = true;
                    //your code to start
                }
            }
            public void stop()
            {
                if(enabled)
                {
                    //your code to stop
                    enabled = false;
                }
            }
        }
