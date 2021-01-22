    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows;
    namespace ListBoxSelectedItems
    {
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }
    }
    public class ViewModel : MyNotifyPropertyChanged
    {
        
        public ViewModel()
        {
            ProductListSource.Add(new Product() { Item = "Item_1", IsSelected = false });
            ProductListSource.Add(new Product() { Item = "Item_2", IsSelected = false });
            ProductListSource.Add(new Product() { Item = "Item_3", IsSelected = false });
        }
        private ObservableCollection<Product> _productList = new ObservableCollection<Product>();
        public ObservableCollection<Product> ProductListSource
        {
            get => _productList;
            set
            {
                _productList = value;
                RaisePropertyChanged(nameof(ProductListSource));
            }
        }
        private readonly Product _selectedProduct;
        
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                var selectedItems = ProductListSource.Where(x => x.IsSelected).ToList();
                this.RaisePropertyChanged(nameof(SelectedProduct));
               
                string s = "{";
                int n = selectedItems.Count;
                for (int i=0; i< n; i++)
                {
                    s += selectedItems[i].ToString();
                    if (i < n - 1) s += ", ";
                }
                s += "}";
                Debug.WriteLine(s + ".Count= " + n);
                
            }
        }
    }
    public class Product : MyNotifyPropertyChanged
    {
        private string _item;
        public string Item
        {
            get => _item;
            set
            {
                _item = value;
                RaisePropertyChanged(nameof(Item));
            }
        }
        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                RaisePropertyChanged(nameof(IsSelected));
            }
        }
        public new string ToString() => _item;
    }
    public class MyNotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    }
