    public MainPage()
        {
            InitializeComponent();
            StarAnimate();
        }
       private void StarAnimate()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
               
                myScroll.ScrollToAsync(LatestElment, ScrollToPosition.Center, true);
                return false; 
            });
        }
