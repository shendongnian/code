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
               BrandGrid.MouseDoubleClick += BrandGrid_MouseDown;
               OrdersGrid.InitializingNewItem += OrdersGrid_InitializingNewItem; ;
               this.Loaded += MainWindow_Loaded;
           }
        private void OrdersGrid_InitializingNewItem(object sender, InitializingNewItemEventArgs e)
        {
            Order newOrder = e.NewItem as Order;
            if (newOrder == null)
                return;
            if(model.CurrentBrand != null)
            {
                newOrder.UpdateRate(model.CurrentBrand.Rate);
            }
            model.BrandCollection.All(b =>
            {
                b.OnBrandSelect += (s, rate) =>
                {
                    newOrder.UpdateRate(model.CurrentBrand.Rate);
                    newOrder.CalculateTotal();
                }; return true;
            });
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            model.Load();
            this.DataContext = model;
        }
        private void BrandGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            Brand selectedbrand = grid.SelectedItem as Brand;
            if (selectedbrand == null)
                return;
            selectedbrand.InvokeBrandSelected();
        }
    }
       internal class MainWindowViewModel : INotifyPropertyChanged
       {
           private Brand currentBrand;
           public ObservableCollection<Brand> BrandCollection { get; private set; }
           public ObservableCollection<Order> OrderCollection { get; private set; }
           public Brand CurrentBrand
           {
               get { return currentBrand; }
               set
               {
                   currentBrand = value;
                   NotifyPropertyChanged();
               }
           }
           public void Load()
           {
               BrandCollection = new ObservableCollection<Brand>
               {
                  new Brand() { Name = "Brand One", Rate = 20 },
                  new Brand() { Name = "Brand Two", Rate = 30 },
                  new Brand() { Name = "Brand Three", Rate = 50 }
               };
               OrderCollection = new ObservableCollection<Order>();
           }
           public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
           {
               PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
           }
           public event PropertyChangedEventHandler PropertyChanged;
       }
       public class Order : INotifyPropertyChanged
       {
          #region Private Variables
          private int length;
          private int quantity;
          private int totalArea;
          private double totalAmount;
          #endregion
          public Order()
          {
          }
           #region Properties
           private double Rate { get; private set; }
           public int Length
           {
             get { return length; }
             set
              {
                   length = value;
                   NotifyPropertyChanged();
                   CalculateArea();
                   CalculateTotal();
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
                   CalculateTotal();
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
           #region Methods
           private void CalculateArea()
           {
               TotalArea = this.Length * this.Quantity;
           }
           public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
           {
               PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
           }
           public void CalculateTotal()
           {
               TotalAmount = this.TotalArea * this.Rate;
           }
           public void UpdateRate(double rate)
           {
               Rate = rate;
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
    }
