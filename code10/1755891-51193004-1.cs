     public partial class MainWindow : Window
        {
             
            bool xs;
            bool os;
            public MainWindow()
       
    
             {
        //snip
        Button Start = new Button();
                    Start.Height = 50;
                    Start.Width = 200;
                    Start.Margin = new Thickness(500, -100, 0, 0);
                    Start.Content = "Start";
                    myStackPanel.Children.Add(Start);
                    Start.Click += Start_Click;
                     xs = Menu.Xs;
                     os = Menu.Os; 
        }
         private void Start_Click(object sender, RoutedEventArgs e)
                {
                      Menu win2 = new Menu();
                      win2.DataChanged += MenuClosed; //handler
                      win2.Show();
                    
                }
                public void MenuClosed(object sender, EventArgs e) //fires after closing menu
                {
                    xs = Menu.Xs; //get new values from Menu for x and o
                    os = Menu.Os;
                }
