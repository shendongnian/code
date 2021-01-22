        private void AddRowToListView(ScannerRow row, bool suspend)
        {
            if (IsFormClosing)
                return;
            if (this.InvokeRequired)
            {
                var A = new Action(() => AddRowToListView(row, suspend));
                this.Invoke(A);
                return;
            }
             //as of here the Code is thread-safe
