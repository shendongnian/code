    private static object _lock = new object();
	private static bool _stoppedNotificationShown = false;
    private void checker(string f, object obj)
    {
        try
        {
            CancellationToken token = (CancellationToken)obj;
            if (token.IsCancellationRequested)
            {
				lock(_lock) {
					if (!_stoppedNotificationShown) {
                		_stoppedNotificationShown = true;
						MessageBox.Show("Stopped", "Checker aborted");
					}
				}
                token.ThrowIfCancellationRequested();
                cts = new CancellationTokenSource();
            } //etc main features of fucntion are hidden from here
