    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    
    namespace WpfApp1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public List<MyComboBoxItem> MyComboBoxItems { get; set; } = new List<MyComboBoxItem>()
            {
                new MyComboBoxItem() {Text = "Item1"},
                new MyComboBoxItem() {Text = "Item2"},
                new MyComboBoxItem() {Text = "Item3"},
    
            };
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
            }
    
            private void OnSelectionChanged(object sender, MyComboBoxSelectionChangedEventArgs e)
            {
                if (e.MyComboBoxItem is MyComboBoxItem item)
                {
                    MyUserControls.Children.Add(
                    new UserControl()
                    {
                        Margin = new Thickness(2),
                        Background = new SolidColorBrush(Colors.LightGray),
                        Content = new TextBlock()
                        {
                            Margin = new Thickness(4),
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            FontSize = 48,
                            FontWeight = FontWeights.Bold,
                            Foreground = new SolidColorBrush(Colors.DarkGreen),
                            Text = item.Text
                        }
                    });
                }
            }
        }
    
        public class MyComboBoxItem
        {
            public string Text { get; set; }
        }
    }
