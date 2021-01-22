        private bool pagedown = false;
        private DispatcherTimer pageDownTimer = new DispatcherTimer();
        private void XBTNPageDown_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            pagedown = true;
            pageDownTimer.Interval = new TimeSpan(0, 0, 0, 0, 30);
            pageDownTimer.Start();
            pageDownTimer.Tick += (o, ea) =>
            {
                if (pagedown)
                {
                    var sv = XDG.FindVisualChild<ScrollViewer>();
                    sv.PageDown();
                    pageDownTimer.Start();
                }
                else
                {
                    pageDownTimer.Stop();
                }
            };
        }
        private void XBTNPageDown_MouseUp(object sender, MouseButtonEventArgs e)
        {
            pagedown = false;
        }
