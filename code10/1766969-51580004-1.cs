        private void TimerEventProcessorForButtonA(Object myObject, EventArgs myEventArgs)
        {
            Debug.WriteLine("TimerEventProcessorForButtonA");
            _myTimerForButtonA.Stop();
            _myTimerForButtonA.Dispose();
            miniButton1.Visibility = System.Windows.Visibility.Hidden;
        }
        private void TimerEventProcessorForButtonB(Object myObject, EventArgs myEventArgs)
        {
            Debug.WriteLine("** TimerEventProcessorForButtonB");
            _myTimerForButtonB.Stop();
            _myTimerForButtonB.Dispose();
            miniButton2.Visibility = System.Windows.Visibility.Hidden;
        }
        public void WaitThisTimeAndHideMiniButton1(int givenTime)
        {
            _myTimerForButtonA = new System.Windows.Forms.Timer();
            _myTimerForButtonA.Tick += new EventHandler(TimerEventProcessorForButtonA);
            _myTimerForButtonA.Interval = givenTime;
            _myTimerForButtonA.Start();
        }
        public void WaitThisTimeAndHideMiniButton2(int givenTime)
        {
            _myTimerForButtonB = new System.Windows.Forms.Timer();
            _myTimerForButtonB.Tick += new EventHandler(TimerEventProcessorForButtonB);
            _myTimerForButtonB.Interval = givenTime;
            _myTimerForButtonB.Start();
        }
        private void buttonA_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Border button = sender as Border;
            button.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(_colorOut);
            WaitThisTimeAndHideMiniButton1(1000); // hide minibuttons
        }
        private void buttonB_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Border button = sender as Border;
            button.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(_colorOut);
            WaitThisTimeAndHideMiniButton2(1000);
        }
        private void buttonA_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_myTimerForButtonA?.Enabled == true)
                _myTimerForButtonA.Stop();
            miniButton1.Visibility = System.Windows.Visibility.Visible;
        }
        private void buttonB_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_myTimerForButtonB?.Enabled == true)
                _myTimerForButtonB.Stop();
            miniButton2.Visibility = System.Windows.Visibility.Visible;
        }
