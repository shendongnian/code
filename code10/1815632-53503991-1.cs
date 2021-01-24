    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }
        public StatusUpdate Status { get; set; } = new StatusUpdate();
        private void PlayCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        
        public void PlayCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Status.Message = "Play";
        }
        public void StopCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Status.Message = "Stop";
        }
    }
