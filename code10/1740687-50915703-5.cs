            protected override void OnStart(string[] args)
            {
            timer1 = new Timer();
            this.timer1.Interval = yourtime;
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timertick); //<== This function starts every "yourtime" in milliseconds
            timer1.Enabled = true;
            Library.WriteErrorLog("Test start"); //<== best practice ever to write a log every beginning
            }
