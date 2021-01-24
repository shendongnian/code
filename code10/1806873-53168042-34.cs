    namespace GridSelection
    {
       /// <summary>
       /// Interaction logic for MainWindow.xaml
       /// </summary>
        public partial class MainWindow : Window
        {
            MainWindowViewModel model = new MainWindowViewModel();
            public MainWindow()
            {
               InitializeComponent();
               OrdersGrid.SelectedCellsChanged += OrdersGrid_SelectedCellsChanged;
               BrandGrid.SelectedCellsChanged += BrandGrid_SelectedCellsChanged;
               this.Loaded += MainWindow_Loaded;
         }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            model.Load();
            this.DataContext = model;
        }
        private void OrdersGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            Order selectedOrder = grid.SelectedItem as Order;
            if (selectedOrder == null)
                return;
            model.BrandCollection.All(b => 
            {
                b.UnsubscribeAll();
                b.OnBrandSelect += (s, rate) => 
                {
                    selectedOrder.CalculateTotal(rate);
                }; return true;
            });
        }
        private void BrandGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            Brand selectedbrand = grid.SelectedItem as Brand;
            if (selectedbrand == null)
                return;
            selectedbrand.InvokeBrandSelected();
        }
    }
    internal class MainWindowViewModel
    {
        public ObservableCollection<Brand> BrandCollection { get; private set; }
        public ObservableCollection<Order> OrderCollection { get; private set; }
        public ICommand AddNewOrderCommand { get; private set; }
        public void Load()
        {
            BrandCollection = new ObservableCollection<Brand>
            {
                new Brand() { Name = "Brand One", Rate = 20 },
                new Brand() { Name = "Brand Two", Rate = 30 },
                new Brand() { Name = "Brand Three", Rate = 50 }
            };
              OrderCollection = new ObservableCollection<Order>();
              AddNewOrderCommand = new CustomCommand(p => 
              {
                  OrderCollection.Add(new Order());
              });
          }
      }
      public class Order : INotifyPropertyChanged
      {
        #region Private Variables
          private int length;
          private int quantity;
          private int totalArea;
          private double totalAmount;
         #endregion
          #region Public Properties
          public int Length
          {
               get { return length; }
               set
               {
                   length = value;
                   NotifyPropertyChanged();
                   CalculateArea();
               }
           }
            public int Quantity
            {
                get { return quantity; }
                set
                {
                    quantity = value;
                    NotifyPropertyChanged();
                    CalculateArea();
                }
            }
            public int TotalArea
            {
                get { return totalArea; }
                set
                {
                    totalArea = value;
                    NotifyPropertyChanged();
                }
            }
            public double TotalAmount
            {
                get { return totalAmount; }
                set
               {
                   totalAmount = value;
                   NotifyPropertyChanged();
               }
            }
            #endregion
            private void CalculateArea()
            {
                TotalArea = this.Length * this.Quantity;
            }
            public void CalculateTotal(double rate)
            {
                TotalAmount = this.TotalArea * rate;
            }
            #region Public Methods
            public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
            #region Events
            public event PropertyChangedEventHandler PropertyChanged;
            #endregion
        }
        public class Brand
        {
            public string Name { get; set; }
            public double Rate { get; set; }
            public void InvokeBrandSelected() => OnBrandSelect?.Invoke(this, Rate);
            public void UnsubscribeAll() => OnBrandSelect = null;
            public event EventHandler<double> OnBrandSelect;
        }
        // Interface 
        public interface ICustomCommand : ICommand
        {
            event EventHandler<object> Executed;
        }
        // Command Class
        public class CustomCommand : ICustomCommand
        {
            #region Private Fields
            private readonly Action<object> _execute;
            private readonly Func<object, bool> _canExecute;
            #endregion
            #region Constructor
            public CustomCommand(Action<object> execute) : this(execute, null)
            {
            }
            public CustomCommand(Action<object> execute, Func<object, bool> canExecute)
            {
                _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute ?? (x => true);
            }
            #endregion
            #region Public Methods
            public bool CanExecute(object parameter)
            {
                return _canExecute(parameter);
            }
            public void Execute(object parameter = null)
            {
                Refresh();
                _execute(parameter);
                Executed?.Invoke(this, parameter);
                Refresh();
            }
            public void Refresh()
            {
                CommandManager.InvalidateRequerySuggested();
            }
            #endregion
            #region Events
            public event EventHandler CanExecuteChanged
            {
                add
                {
                    CommandManager.RequerySuggested += value;
                }
                remove
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
            public event EventHandler<object> Executed;
            #endregion
        }
    }
