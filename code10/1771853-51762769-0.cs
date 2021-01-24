        private void ring() {
        if (System.DateTime.Now.ToString("HH:mm") == temp && songisplaying == false) {
            soundplayer.PlayLooping();
            timer1.Stop();//Stop your timer.
            songisplaying = true;
            if (WindowState == FormWindowState.Minimized)
            {
                this.Show();
                WindowState = FormWindowState.Normal;
            }
            wakeupForm win = new wakeupForm();
            win.Form_Closed += win_Closed;
            win.Show();
        }
         private void wnd_Closed(object sender, EventArgs e)
         {
            timer1.Start();
         }
