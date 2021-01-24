    public partial class MainWindow : Window, IDisposable
    {
        private Timer _t;
        public MainWindow()
        {
            Closing += OnClosing;
        }
        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Dispose(true);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(_t != null)
                _t.Dispose();
            _t = new Timer(DoingWork, null, 0, 5000);
        }
        private void DoingWork(object state)
        {
            //....
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && _t != null)
                _t.Dispose();
        }
    }
