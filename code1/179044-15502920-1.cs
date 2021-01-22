    using System.Windows;
    using System.Windows.Media;
    using System.Collections.ObjectModel;
    
    namespace icube
    {
        /// <summary>
        /// Interaktionslogik für MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                var obcoll = new ObservableCollection<SolidColorBrush>();
    
                obcoll.Add(Brushes.Red);
                obcoll.Add(Brushes.Green);
                obcoll.Add(Brushes.Yellow);
                obcoll.Add(Brushes.Blue);
                obcoll.Add(Brushes.Orange);
    
                myLB.ItemsSource = obcoll;
    
                DataContext = new myClass();
            }
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                //importent if you want to see your selected Element
                myLB.ScrollIntoView(myLB.SelectedItem);
            }
        }
    }
