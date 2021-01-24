    List<string> menuPages = new List<string>() { "Home", "Media", "Settings" };
    List<TextBlock> textBlocks = new List<TextBlock>();
    public MainPage()
    {
        this.InitializeComponent();
        createHeaders();
    }
    private void createHeaders()
    {
        for (int i = 0; i < menuPages.Count; i++)
        {
            TextBlock iheader = new TextBlock();
            iheader.Name = menuPages[i];
            iheader.Text = menuPages[i];              
            iheader.FontSize = 32;
            textBlocks.Add(iheader);
            Stacky.Children.Add(iheader); 
        }
    }
    private void change_Click(object sender, RoutedEventArgs e)
    {
        for (int i = 0; i < textBlocks.Count; i++)
        {
            textBlocks[i].Text = "foo";
        }
    } 
