        void SafeUpdateStatusText(string text)
        {
            // update status text on event thread if necessary
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate
            {
                lblstatus.Content = text;
            }, null);
        }
