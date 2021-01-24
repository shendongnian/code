    public partial class App
    {
        [STAThread]
        public static void Main(string[] args)
        {
            new MainWindow(new AccountViewModel("123456789")).ShowDialog();
        }
    }
