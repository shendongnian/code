        private void TestTimer()
        {
            var t = new System.Timers.Timer(5000);
            t.Elapsed += T_Elapsed;
            t.Start();
        }
        private void T_Elapsed(object sender, 
        System.Timers.ElapsedEventArgs e)
        {
            // Do your stuff
        }
