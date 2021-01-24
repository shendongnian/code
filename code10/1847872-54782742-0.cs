    private double previousScrollPosition = 0;
    
            public MainPage()
            {
                InitializeComponent();
            }
    
            void Handle_Scrolled(object sender, Xamarin.Forms.ScrolledEventArgs e)
            {
                if (previousScrollPosition < e.ScrollY)
                {
                    //scrolled down
                    Console.WriteLine("!!!!!!!!!scrolled down   ScrollY=>" + textScroll.ScrollY);
                }
                else
                {
                    //scrolled up
                    Console.WriteLine("!!!!!!!!!scrolled up   ScrollY=>" + textScroll.ScrollY);
                }
                previousScrollPosition = e.ScrollY;
            }
