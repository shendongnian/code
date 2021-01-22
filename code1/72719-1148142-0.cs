    [STAThread]
    public static void Main()
    {
        App app = new App();
        app.StartupUri = new System.Uri("/Project1;component/Class1.xaml", System.UriKind.Relative);                     
        app.Run();
    }
