        private delegate void SerialPortKeyUpHandler(int keyCode, TimeSpan timeHeld);
        private event SerialPortKeyUpHandler SerialPortKeyUp;
        CancellationTokenSource cancellationTokenSource;
        private int keyCode;
        private const int accuracy = 75; //the interval I'm talking about
        private void StartCapturing(int keyCode)
        {
            this.keyCode = keyCode;
            DateTime start = DateTime.UtcNow;
            cancellationTokenSource.CancelAfter(accuracy);
            ParameterizedThreadStart threadStart = new ParameterizedThreadStart((object cancellationTokenObj) =>
            {
                CancellationToken cancellationToken = (CancellationToken)cancellationTokenObj;
                while (!cancellationToken.IsCancellationRequested) ; //wait until we make sure no more of the same key data is being sent
                SerialPortKeyUp?.Invoke(keyCode, DateTime.UtcNow.Subtract(start));
            });
            Thread thread = new Thread(threadStart);
            thread.Start(cancellationTokenSource.Token);
        }
        private void KeyDownCallback(object sender, KeyEventArgs e)
        {
            if (cancellationTokenSource == null || cancellationTokenSource.IsCancellationRequested)
            {
                cancellationTokenSource = new CancellationTokenSource();
                StartCapturing(e.KeyValue);
            }
            else
            {
                if (e.KeyValue == keyCode)
                {
                    cancellationTokenSource.CancelAfter(accuracy);
                }
                else
                {
                    cancellationTokenSource.Cancel();
                    cancellationTokenSource.Dispose();
                    cancellationTokenSource = new CancellationTokenSource();
                    StartCapturing(e.KeyValue);
                }
            }
        }
        private void KeyUpCallback(int keyCode, TimeSpan heldTime)
        {
            Debug.WriteLine($"Key {keyCode} is up. The key was held for {heldTime.TotalSeconds.ToString("#.00")} second(s).");
        }
