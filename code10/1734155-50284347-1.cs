    public partial class MainWindow : Window
    {
        static Process process; //making process class level member;
        Thread mythread = new Thread(() =>
        {
            process = new Process();
            process.StartInfo.FileName = @"notepad.exe";
            process.Start();
        });
        public MainWindow()
        {
            InitializeComponent();
            mythread.Start();   
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            process.Kill(); //killing the actual process.
            mythread.Abort();
        }
    }
