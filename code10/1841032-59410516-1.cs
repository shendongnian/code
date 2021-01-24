    using Microsoft.UI.Xaml.Controls;
    using System.Collections.Generic;
    using Windows.UI.Xaml.Controls;
    
    namespace UWPTest
    {
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
                var tabView = new TabView();
                var itemSource = new List<TabViewItem>
                {
                    new TabViewItem{ Header = "Tab 1", Content = new TextBlock{ Text = "Hello Tab 1!"} },
                    new TabViewItem{ Header = "Tab 2", Content = new TextBlock{ Text = "Hello Tab 2!"} },
                    new TabViewItem{ Header = "Tab 3", Content = new TextBlock{ Text = "Hello Tab 3!"} },
                };
                tabView.TabItemsSource = itemSource;
                MainPageFrame.Content = tabView;
            }
        }
    }
