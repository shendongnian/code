    private ObservableCollection<Platform> m_platforms;
    public MainWindow()
    {
        InitializeComponent();
        m_platforms = new ObservableCollection<Platform>();
        m_platforms.Add(new Platform("PC"));
        m_platforms.Add(new Platform("PS3"));
        m_platforms.Add(new Platform("Xbox 360"));
        DataContext = m_platforms;
    }
    public void OnBuild(object sender, RoutedEventArgs e)
    {
        string text = "";
        foreach (Platform platform in m_platforms)
        {
            if (platform.Selected)
            {
                text += platform.Name + " ";
            }
        }
        if (text == "")
        {
            text = "none";
        }
        MessageBox.Show(text, "WPF TEST");
    }
    public void OnTogglePC(object sender, RoutedEventArgs e)
    {
        m_platforms[0].Selected = !m_platforms[0].Selected;
    }
    
