    class Test
    {
        [@STAThreadAttribute()]
        public static void Main(string[] args)
        {
            MainWindow w = new MainWindow();
            Binding b = new Binding();
            b.Source = new Data();
            SetBinding(DataContextProperty, b);
   
            w.ShowDialog();
        }
    }
