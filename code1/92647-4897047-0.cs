    private static Grid root;
    private void Application_Startup(object sender, StartupEventArgs e)
    {
        root = new Grid();
        root.Children.Add(new MainPage());
        this.RootVisual = root;
    }
    public static void Navigate(UserControl newPage)
    {
        UserControl oldPage = root.Children[0] as UserControl;
        root.Children.Add(newPage);
        root.Children.Remove(oldPage);
    }
