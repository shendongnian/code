    private void FileCount(string fileName)
    {
            Application.Current.Dispatcher.Invoke(() => {
                txtLabel_Log.Text = fileName;   // < -- Calling Method UI Error
            });
    }
