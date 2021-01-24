        public Stopwatch stopwatch = new Stopwatch();
        bool started = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (started == false)
            {
                started = true;
                button1.Text = "Stop";
                //---------Clock Code-------------
                stopwatch.Start();
            }
            else
            {
                started = false;
                button1.Text = "Start";
                //---------Clock Code------------
                stopwatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopwatch.Elapsed;
                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                MessageBox.Show(elapsedTime);
            }
        }
