    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
        //When your application finished initializing it's components this will run
        MessageBox.Show("Hello User!");
            }
    
    //This being the event
            private void mainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
            {
                MessageBox.Show("Goodbye User!");
            }
        }
