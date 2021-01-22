    using System;
    using System.ComponentModel;
    
    using System.Windows;
    
    
    namespace ScrollTest
    {
        public partial class TestWindow : Window
        {
            public TestWindow()
            {
                InitializeComponent();
            }
    
            private void OnLoaded(object sender, RoutedEventArgs e)
            {
                _scroll.ScrollToVerticalOffset((DataContext as VM).ScrollOffset);
            }
    
            private void OnClosing(object sender, CancelEventArgs e)
            {
                (DataContext as VM).ScrollOffset = _scroll.VerticalOffset;
            }
        }
    
        public class VM
        {
            public double ScrollOffset { get; set; }
        }
    }
