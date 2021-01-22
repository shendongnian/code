        private void InsertBasicVaraibles()
        {
             int functionStopwatch = 0;
             while(true)
             {
               try
               {
                 functionStopwatch = Environment.TickCount;
                 DataTablesMutex.WaitOne();//mutex for my shared resources
                 //insert into DB 
               }
               catch (Exception ex)
               {
                 //Handle            
               }
               finally            
               {                
                  DataTablesMutex.ReleaseMutex();
               }
               //simulate the timer tick value
               functionStopwatch = Environment.TickCount - functionStopwatch;
               int diff = INSERTION_PERIOD - functionStopwatch;
               int sleep = diff >= 0 ?  diff:0;
               Thread.Sleep(sleep);
            }
        }
