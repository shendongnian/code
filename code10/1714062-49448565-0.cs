        private void LongProcess()
        {
            // Write your code/call method to change cursor
            Cursor = Cursors.Wait;
            Task.Factory.StartNew(() =>
            {
                // Write your code which do long process or
                // call method which do the same
                System.Threading.Thread.Sleep(10000);
            }).ContinueWith(t =>
            {
                Dispatcher.Invoke(() =>
                {
                    // Write your code/call method to change cursor back to normal
                    Cursor = Cursors.Arrow;
                });
            });
        }
