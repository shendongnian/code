    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Threading;
    
    namespace asyncTest
    {
        /// <summary>
        /// Interaction logic for BetterWindow.xaml
        /// </summary>
        public partial class BetterWindow : Window
        {
            public BetterWindow()
            {
                InitializeComponent();
    
                var timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(10);
                timer.Tick += Timer_Tick;
                timer.Start();
            }
    
            private async void Timer_Tick(object sender, EventArgs e)
            {
                // "async void" is generally frowned upon, but it is acceptable in event handlers.
                if (await ShouldExit())
                {
                    Close();
                }
            }
    
            private async Task<bool> ShouldExit()
            {
                Debug.WriteLine("Checking the DB");
                //Simulate a long DB operation
                await Task.Delay(TimeSpan.FromSeconds(5));
                return chkAllowClose.IsChecked.GetValueOrDefault(false);
            }
        }
    }
  
