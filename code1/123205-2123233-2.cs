       private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.WaitOnLoad = false;
            pictureBox1.LoadCompleted += new AsyncCompletedEventHandler(pictureBox1_LoadCompleted);
            pictureBox1.LoadAsync("image.jpg");
        }
        void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //System.Timers.Timer is used as it supports multithreaded invocations
            System.Timers.Timer timer = new System.Timers.Timer(5000); 
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            //set this so that the timer is stopped once the elaplsed event is fired
            timer.AutoReset = false; 
            timer.Enabled = true;
        }
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            MessageBox.Show("test"); //just to test, here should be the code to play the mp3
        }
