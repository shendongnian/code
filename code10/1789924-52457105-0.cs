    Color bgColor;
    public MainWindow()
    {
       InitializeComponent();
       this.Loaded += delegate (object sender, RoutedEventArgs e) {
            bgColor = ((SolidColorBrush)Background).Color;
            MouseEnter += EnterAnim;
            MouseLeave += LeaveAnim;
       };
    }
    
    private void EnterAnim(object sender, MouseEventArgs e)
    {
        ColorAnimation animC = new ColorAnimation(BGHover, TimeSpan.FromMilliseconds(200));
        myBtn.Background.BeginAnimation(SolidColorBrush.ColorProperty, animC);
    }
    private void LeaveAnim(object sender, MouseEventArgs e)
    {
        ColorAnimation animC = new ColorAnimation(bgColor, TimeSpan.FromMilliseconds(200));
        myBtn.Background.BeginAnimation(SolidColorBrush.ColorProperty, animC);
    }
