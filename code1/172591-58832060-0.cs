        private void nameOfMethod()
        {
            //do something
        }
        /// <summary>
        /// run method at 22:00 every day
        /// </summary>
        private void runMethodEveryDay()
        {
            var runAt = DateTime.Today + TimeSpan.FromHours(22);
            
            if(runAt.Hour>=22)
                runAt = runAt.AddDays(1.00d); //if aplication is started after 22:00 
            var dueTime = runAt - DateTime.Now; //time before first run ; 
            
            long broj3 = (long)dueTime.TotalMilliseconds;
            TimeSpan ts2 = new TimeSpan(24, 0, 0);//period of repeating method
            long broj4 = (long)ts2.TotalMilliseconds;
            timer2 = new System.Threading.Timer(_ => nameOfMethod(), null, broj3, broj4);
        }
