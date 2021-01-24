    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ProgressBarEvent.GetInstance().Show += ShowProgressBar;
            ProgressBarEvent.GetInstance().Close += CloseProgressBar;
        }
        private Views.ProgressBar progressBarWindow;
        private void CloseProgressBar(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() => progressBarWindow.Close());
        }
        private void ShowProgressBar(object sender, EventArgs e)
        {
            progressBarWindow = new Views.ProgressBar();
            var activeWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive);
            progressBarWindow.Owner = activeWindow;
            progressBarWindow.Show();
        }
    }
