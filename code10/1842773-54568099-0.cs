        private IDisposable _subscription = null;
        private void MinuteTimerLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _subscription =
                Observable
                    .Interval(TimeSpan.FromMilliseconds(250.0))
                    .Select(x => String.Format("{0:00}", x))
                    .ObserveOnDispatcher()
                    .Subscribe(x => MinuteTimerLabel.Content = x);
        }
        private void MinuteTimerLabel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _subscription.Dispose();
        }
