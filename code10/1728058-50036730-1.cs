    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace WPFTest
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                var dahList = new List<StatsOperation>();
                dahList.Add(new StatsOperation
                {
                    Operation = "Op A",
                    Choices = new string[] { "One", "Two", "Three" },
                });
                dahList.Add(new StatsOperation
                {
                    Operation = "Op B",
                    Choices = new string[] { "4", "5", "6" },
                });
                this.MyListView.ItemsSource = dahList;
            }
        }
    
        internal class StatsOperation
        {
            public string Operation { get; set; }
            public string[] Choices { get; set; }
        }
    }
