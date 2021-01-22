     public class IdleTimeService
    {
        //Importing the Dll & declaring the necessary function
        [DllImport("user32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
        /// <summary>
        /// return the current idle time (in ms)
        /// </summary>
        /// <returns>current idle time in ms</returns>
        public static int GetIdleTime()
        {
            //Creating the object of the structure
            LASTINPUTINFO lastone = new LASTINPUTINFO();
            //Initialising  
            lastone.cbSize = (uint)Marshal.SizeOf(lastone);
            lastone.dwTime = 0;
            int idleTime = 0;
            //To get the total time after starting the system.
            int tickCount = System.Environment.TickCount;
            //Calling the dll function and getting the last input time.
            if (GetLastInputInfo(ref lastone))
            {
                idleTime = tickCount - (int)lastone.dwTime;
                return idleTime;
            }
            else
                return 0;
        }
    }
