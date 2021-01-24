    public partial class MainWindow : Window
        {
            DispatcherTimer disTime = new DispatcherTimer();
            public MainWindow()
            {
                InitializeComponent();
                disTime.Interval = new TimeSpan(0, 0, 10);
                disTime.Tick += disTime_Tick;
                disTime.Start();
            }
            private void disTime_Tick(object sender, EventArgs e)
            {
                if (RedLight.Fill == Brushes.Red)
                {
                    RedLight.Fill = Brushes.PaleVioletRed;
                    GreenLight.Fill = Brushes.Green;
                }
                else if (GreenLight.Fill == Brushes.Green)
                {
                    GreenLight.Fill = Brushes.PaleGreen;
                    OrangeLight.Fill = Brushes.Orange;
                    disTime.Interval = new TimeSpan(0, 0, 5);
                }
                else if (OrangeLight.Fill ==Brushes.Orange)
                {
                    OrangeLight.Fill = Brushes.PaleGoldenrod;
                    RedLight.Fill = Brushes.Red;
                    disTime.Interval = new TimeSpan(0, 0, 10);
                }
            }
        }
