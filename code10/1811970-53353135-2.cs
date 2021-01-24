        public partial class Window1 : Window
        {
            private Timer timer = null;
            private Storyboard sb = null;
            public Window1()
            {
                InitializeComponent();
                timer = TimerParent.GlobalTimer;
                timer.Elapsed += OnTimedEvent;
                sb = this.Resources["TestStoryboard"] as Storyboard;
            }
            private  void OnTimedEvent(Object source, ElapsedEventArgs e)
            {
                Application.Current.Dispatcher.InvokeAsync(new Action(() =>
                {
                    sb.Begin();
                }));
            }
        }
