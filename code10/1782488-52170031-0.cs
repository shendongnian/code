     public class SettingsWindow : Window
    {
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.IsClosed = true;
        }
        public bool IsClosed { get; private set; }
    }
    public partial class MainWindow : Window
    {
        private SettingsWindow settingsWindow;
        private void settings_Click(object sender, RoutedEventArgs e)
        {
            if (this.settingsWindow == null || this.settingsWindow.IsClosed) 
            {
                this.settingsWindow = new SettingsWindow();
            }
            this.settingsWindow.Show();
            this.settingsWindow.Focus();
        }
    }
