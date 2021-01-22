      public string OpeningTimesString
          {
             get
             {
                if (!this.OpeningTimes.IsLoaded)
                   this.OpeningTimes.Load();
                var groups = (from s in this.OpeningTimes
                           orderby s.Day, s.Start, s.Stop
                           group s by new { Stop = formatTime(s.Stop), Start = formatTime(s.Start), s.Day } into gr
                           select new
                           {
                              Time = gr.Key.Start + "-" + gr.Key.Stop,
                              Day = gr.Key.Day
                           }).ToList();
                string result = "";
                int tmp = 1;
                for (int i = 0; i < groups.Count(); i++)
                {
    
    
                   //One one = new One();
                   bool exit = false;
                   tmp = i;
                   while (exit == false)
                   {
                      if (i + 1 < groups.Count && groups[i].Time.Equals(groups[i + 1].Time))
                      {
                         i++;
                      }
                      else
                      {
                         if (tmp != i)
                            result += (NormalDayOfWeek)(groups[tmp].Day - 1) + "-" + (NormalDayOfWeek)(groups[i].Day - 1) + " : " + groups[i].Time + "<br />";
                         else
                            result += (NormalDayOfWeek)(groups[i].Day - 1) + " : " + groups[i].Time + "<br />";
                         exit = true;
                      }
                   }
                }
    
                if (result.IsNotNull())
                   return result;
                else
                   return "[%Not yet defined]";
             }
          }
