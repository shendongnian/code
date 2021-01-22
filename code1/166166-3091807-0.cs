     [@STAThreadAttribute()]
     public static void Main(string[] args)
     {
         MainWindow w = new MainWindow();
         w.DataContext = new Data();
         w.ShowDialog();
     }
