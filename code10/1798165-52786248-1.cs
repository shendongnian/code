    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Timers;
    using System.Windows;
    
    namespace WpfApplication1
    {
        public class Model
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    
        public class ViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            private readonly Model[] items;
    
            public ViewModel()
            {
                items = Enumerable.Range(1, 101)
                                  .Select(x => new Model
                                  {
                                      Id = x,
                                      Name = $"Item {x}"
                                  })
                                  .ToArray();
            }
    
            public Model[] Items => items;
    
            private Model selectedItem;
            public Model SelectedItem
            {
                get { return selectedItem; }
                set
                {
                    selectedItem = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItem)));
                }
            }
    
        }
    
        public partial class MainWindow : Window
        {
            private readonly Timer timer;
            private readonly ViewModel model;
            private readonly Random random;
    
            public MainWindow()
            {
                InitializeComponent();
                model = new ViewModel();
                random = new Random();
                timer = new Timer(2000);
    
                DataContext = model;
    
                timer.Elapsed += Timer_Elapsed;
                timer.Start();
            }
    
            private void Timer_Elapsed(Object sender, ElapsedEventArgs e)
            {
                var index = random.Next(model.Items.Length);
                model.SelectedItem = model.Items[index];
            }
    
            private void DataGrid_SelectionChanged(Object sender, System.Windows.Controls.SelectionChangedEventArgs e)
            {
                if (MyDataGrid.SelectedItem != null)
                {
                    MyDataGrid.ScrollIntoView(MyDataGrid.SelectedItem);
                }
            }
    
            protected override void OnClosing(CancelEventArgs e)
            {
                base.OnClosing(e);
    
                timer.Stop();
                timer.Dispose();
            }
        }
    }
