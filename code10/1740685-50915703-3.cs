            protected override void OnStart(string[] args)
            {
            timer1 = new Timer();
            this.timer1.Interval = 43200000;
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timertick);
            timer1.Enabled = true;
            Library.WriteErrorLog("Test start"); //<== best practice ever
            }
