    namespace Viking.Test
    {
        public partial class DataBindTest : Window
        {
            public DataBindTest()
            {
                InitializeComponent();
            }
    
            private void AddOne_Click(object sender, RoutedEventArgs e)
            {
                var list = this.Resources["Context"] as DiscoveredItemList;
                list.AddRandomItem();
            }
        }  // End of Class 
    }  // End of Namespace 
    
    //The following is the class that contains the dataset
    namespace Viking.Test.Discovery
    {
        public class DiscoveredItem
        {
            public DiscoveredItem() { }
    
            public string Field1 { get; set; }
    
        }  // End of Class 
    
         public class DiscoveredItemList
        {
            public ObservableCollection<DiscoveredItem> DiscoveredItems { get; set; }
            private Random RandomGen;
    
            public DiscoveredItemList()
            {
                DiscoveredItems = new ObservableCollection<DiscoveredItem>();
                RandomGen = new Random();
            }
    
    
            public void AddRandomItem()
            {
                DiscoveredItem di = new DiscoveredItem(); ;
                di.Field1 = RandomGen.Next(1, 10).ToString();
                DiscoveredItems.Add(di);
            }
        }  // End of Class 
    }
