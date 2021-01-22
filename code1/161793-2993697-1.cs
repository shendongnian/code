    using System;
    using System.Windows;
    using System.Windows.Threading;
    
    namespace AutoScrollTest
    {
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
    
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = new TimeSpan(0, 0, 2);
                timer.Tick += ((sender, e) =>
                    {
                        _contentCtrl.Height += 10;
    
                        if (_scrollViewer.VerticalOffset == _scrollViewer.ScrollableHeight)
                        {
                            _scrollViewer.ScrollToEnd();
                        }
                    });
                timer.Start();
            }
        }
    }
