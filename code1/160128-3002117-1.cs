    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    
    namespace ScrollIntoViewTest
    {
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
    
                Data = new List<string>();
                for (int i = 0; i < 100; i++)
                {
                    Data.Add(i.ToString());    
                }
    
                DataContext = this;
            }
    
            public List<string> Data { get; set; }
    
            private void OnListViewLoaded(object sender, RoutedEventArgs e)
            {
                // Assumes that the listview consists of a scrollviewer with a border around it
                // which is the default.
                Border border = VisualTreeHelper.GetChild(sender as DependencyObject, 0) as Border;
                _scrollViewer = VisualTreeHelper.GetChild(border, 0) as ScrollViewer;
            }
    
            private void OnScrollIntoView(object sender, SelectionChangedEventArgs e)
            {
                string item = (sender as ComboBox).SelectedItem as string;
                double index = Data.IndexOf(item) - Math.Truncate(_scrollViewer.ViewportHeight / 2);
                _scrollViewer.ScrollToVerticalOffset(index);
            }
    
            private ScrollViewer _scrollViewer;
        }
    }
