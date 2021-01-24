      public MainPage()
            {
                this.InitializeComponent();           
            }
    
            private void Button1_Click(object sender, RoutedEventArgs e)
            {
                //Brush newBackgroundBrushRed = new SolidColorBrush(Colors.Red);           
    
                if (grid1.Background == newBackgroundBrushImage)
                {
                    grid1.Background = bgimg2brush;
                }
    else
                {
                    grid1.Background = newBackgroundBrushImage;
                }
