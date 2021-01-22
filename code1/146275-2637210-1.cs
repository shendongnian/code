    namespace WpfApplication36{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
          private ICollection<Product> products;
        private ListCollectionView view;
        private void cmdNext_Click(object sender, RoutedEventArgs e)
        {    
            view.MoveCurrentToNext();          
        }
        private void cmdPrev_Click(object sender, RoutedEventArgs e)
        {
            view.MoveCurrentToPrevious();
        }
        private void lstProducts_SelectionChanged(object sender, RoutedEventArgs e)
        {
           // view.MoveCurrentTo(lstProducts.SelectedItem);
        }
        private void view_CurrentChanged(object sender, EventArgs e)
        {
            lblPosition.Text = "Record " + (view.CurrentPosition + 1).ToString() +
                " of " + view.Count.ToString();
            cmdPrev.IsEnabled = view.CurrentPosition > 0;
            cmdNext.IsEnabled = view.CurrentPosition < view.Count - 1; 
        }
        public Window1()
        {
             InitializeComponent();
            
            products = AddProduct() ;
            this.DataContext = products;
            view = (ListCollectionView)CollectionViewSource.GetDefaultView(this.DataContext);
            view.CurrentChanged += new EventHandler(view_CurrentChanged);
            lstProducts.ItemsSource = products;            
        
        }
        private Collection<Product> AddProduct()
        {
            Collection<Product> test = new Collection<Product>();
            Product prod=null;
        
            prod=new Product();
            prod.ModelName ="BMW";
                prod.ModelNumber ="Q234";
                    prod.Description="BMWWWWWWWWWWWW";
                        prod.UnitCost="$3333333";
                        test.Add(prod);
                        prod = new Product();
                        prod.ModelName = "BMW11";
                        prod.ModelNumber = "Q234111";
                        prod.Description = "BMWWbbb";
                        prod.UnitCost = "$3333333";
                        test.Add(prod);
                        prod = new Product();
                        prod.ModelName = "BM3W";
                        prod.ModelNumber = "Q233334";
                        prod.Description = "BMWb33bbb";
                        prod.UnitCost = "$3333333";
                        test.Add(prod);
            return test;
        }
      
    }
    public class Product
    {
        private string modelNumber;
        public string ModelNumber
        {
            get {return modelNumber;  }
            set{ modelNumber=value; }
        }
         private string modelName;
        public string ModelName
        {
            get {return modelName;  }
            set{ modelName=value ;}
        }
        private string unitCost;
        public string UnitCost
        {
            get { return unitCost; }
            set { unitCost = value; }
        }
        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        
    }
}
