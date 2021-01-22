    private void Run_Timer()
        {
            DateTime tday = new DateTime();
            tday = DateTime.Today;
            TimeSpan Start_Time = new TimeSpan(8,15,0);
            DateTime Starter = tday + Start_Time;
            Start_Time = new TimeSpan(20, 15, 0);
            DateTime Ender = tday + Start_Time;
            for (int i = 0; i <= 23; i++)
            {
                Start_Time = new TimeSpan(i, 15, 0);
                tday += Start_Time;
                if (((tday - DateTime.Now).TotalMilliseconds > 0) && (tday >= Starter) && (tday <= Ender))
                {
                    Time_To_Look = tday;
                    timer1.Interval = Convert.ToInt32((tday - DateTime.Now).TotalMilliseconds);
                    timer1.Start();
                    MessageBox.Show(Time_To_Look.ToString());
                    break;
                }
            }
        }
