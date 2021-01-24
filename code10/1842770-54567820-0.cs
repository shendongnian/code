    private void MinuteTimerLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        new Thread(Timer).Start();
    }
    private void Timer() {
        while(true)
        {
            if (timerMinute == 99)
            {
                return;
            }
            timerMinute += 1;
            minuteTimerLabel.Content = String.Format("{0:00}", timerMinute);
            Thread.Sleep(250);
        }
    }
