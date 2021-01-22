        private bool balloonTipShown;
        private Timer balloonTimer;
        private void trayIcon_MouseMove(object sender, MouseEventArgs e)
        {
            if (balloonTipShown)
            {
                return;
            }
            balloonTipShown = true;
            trayIcon.MouseMove -= trayIcon_MouseMove;
            balloonTimer = new Timer();
            balloonTimer.Tick += balloonTimer_Tick;
            balloonTimer.Interval = 2005;
            balloonTimer.Start();
            trayIcon.ShowBalloonTip(2000);
        }
        void balloonTimer_Tick(object sender, EventArgs e)
        {
            balloonTipShown = false;
            balloonTimer.Stop();
            balloonTimer.Dispose();
            trayIcon.MouseMove += trayIcon_MouseMove;
        }
