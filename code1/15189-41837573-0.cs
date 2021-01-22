        private bool IsServiceDatabaseProcessReadyToStart()
        {
            bool isGoodParms = true;
            DateTime currentTime = DateTime.Now;
            //24 Hour Clock
            string[] timeSpan = currentTime.ToString("HH:mm:ss").Split(':');
            //Default to Noon
            int hr = 12;
            int mn = 0;
            int sc = 0;
            if (!string.IsNullOrEmpty(timeSpan[0]))
            {
                hr = Convert.ToInt32(timeSpan[0]);
            }
            else
            {
                isGoodParms = false;
            }
            if (!string.IsNullOrEmpty(timeSpan[1]))
            {
                mn = Convert.ToInt32(timeSpan[1]);
            }
            else
            {
                isGoodParms = false;
            }
            if (!string.IsNullOrEmpty(timeSpan[2]))
            {
                mn = Convert.ToInt32(timeSpan[2]);
            }
            else
            {
                isGoodParms = false;
            }
            if (isGoodParms == true )
            {
                TimeSpan currentTimeSpan = new TimeSpan(hr, mn, sc);
                TimeSpan minTimeSpan = new TimeSpan(0, 0, 0);
                TimeSpan maxTimeSpan = new TimeSpan(0, 04, 59);
                if (currentTimeSpan >= minTimeSpan && currentTimeSpan <= maxTimeSpan)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
