      private void InteractivePause(TimeSpan length)
      {
         DateTime start = DateTime.Now;
         TimeSpan restTime = new TimeSpan(200000); // 20 milliseconds
         while(true)
         {
            System.Windows.Forms.Application.DoEvents();
            TimeSpan remainingTime = start.Add(length).Subtract(DateTime.Now);
            if (remainingTime > restTime)
            {
               System.Diagnostics.Debug.WriteLine(string.Format("1: {0}", remainingTime));
               // Wait an insignificant amount of time so that the
               // CPU usage doesn't hit the roof while we wait.
               System.Threading.Thread.Sleep(restTime);
            }
            else
            {
               System.Diagnostics.Debug.WriteLine(string.Format("2: {0}", remainingTime));
               if (remainingTime.Ticks > 0)
                  System.Threading.Thread.Sleep(remainingTime);
               break;
            }
         }
      }
