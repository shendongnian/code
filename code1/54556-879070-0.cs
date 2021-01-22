    using System.Timers;
    public class usersession
    {
        private static bool sessionalive;
        private static Timer usertimer;
        public static bool SessionAlive
        {
            get { return sessionalive; }
            set { sessionalive = value; }
        }
        public static void  BeginTimer()
        {
            try
            {
               SessionAlive = true;
                //usertimer.Start();
               usertimer = new Timer(int.Parse(ConfigurationManager.AppSettings["sessiontime"].ToString()));
                usertimer.Enabled = true;
               usertimer.AutoReset = false;  
               usertimer.Elapsed += new ElapsedEventHandler(DisposeSession);
            }
            catch (Exception ex)
            {
                return;
            }
            
        }
       
        private static void  DisposeSession(object source, ElapsedEventArgs e)
        {
            try
            {
                SessionAlive = false;
            }
            catch (System.Exception ex)
            {
                return;
            }
            
        }
        public static void ResetTimer()
        {
            try
            {
                SessionAlive = true;
                usertimer.Stop();
                usertimer.Start();
            }
            catch (Exception ex)
            {
                
                return;
            }
            
        }
        
    }
