    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace FlowListTest
    {
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
    
                DataContext = this;
            }
    
            public IEnumerable<string> Items
            {
                get
                {
                    for (int i = 0; i < 100; i++)
                    {
                        yield return i.ToString();
                    }
                }
            }
    
            private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                (sender as ListBox).SelectedIndex = _selectedIndex;
            }
    
            private void OnScrollChanged(object sender, ScrollChangedEventArgs e)
            {
                _selectedIndex = (int)(e.HorizontalOffset + Math.Truncate(e.ViewportWidth / 2));
                (sender as ListBox).SelectedIndex = _selectedIndex;
            }
    
            private int _selectedIndex;
        } 
    }
