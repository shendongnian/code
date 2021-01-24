      public partial class MainWindow : Window
      {
        public MainWindow()
        {
          InitializeComponent();
    
          m_preventFeedback = true;
          ItemsList = new ObservableCollection<VMItem>
          {
            new VMItem(new Item("John", 1234), 2),
            new VMItem(new Item("Peter", 2345), 2),
            new VMItem(new Item("Michael", 3456), 2),
          };
    
          ListCollectionView view = new ListCollectionView(ItemsList);
          view.GroupDescriptions.Add(new PropertyGroupDescription("CategoryId", new ItemGroupValueConverter()));
          MyCombo.ItemsSource = view;
          m_preventFeedback = false;
        }
    
        private ObservableCollection<VMItem> ItemsList = new ObservableCollection<VMItem>();
    
        bool m_preventFeedback = false;
    
        private void MyCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          if (m_preventFeedback) return;
    
          if (MyCombo.SelectedItem is VMItem item)
          {
            m_preventFeedback = true;
            VMItem mru = ItemsList.FirstOrDefault(i => i.Name == item.Name && i.CategoryId == 1) ?? new VMItem(item.Item, 1);
    
            ItemsList.Remove(mru);
            ItemsList.Insert(0, mru);
            MyCombo.SelectedItem = mru;
            m_preventFeedback = false;
          }
        }
      }
    
      public class ItemGroupValueConverter : IValueConverter
      {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
          switch ((int)value)
          {
            case 1: return "Last Used";
            case 2: return "Available Items";
          }
    
          return "N/A";
    
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
          return value;
        }
      }
    
      public class VMItem : INotifyPropertyChanged
      {
        private Item m_item;
    
        public VMItem(Item item, int categoryId)
        {
          m_item = item;
          m_categoryId = categoryId;
        }
    
        public string Name
        {
          get { return m_item.Name; }
          set
          {
            m_item.Name = value;
            OnPropertyChanged("Name");
          }
        }
    
        public int Value
        {
          get { return m_item.Value; }
          set
          {
            m_item.Value = value;
            OnPropertyChanged("Value");
          }
        }
    
        private int m_categoryId;
        public int CategoryId
        {
          get { return m_categoryId; }
          set
          {
            m_categoryId = value;
            OnPropertyChanged("CategoryId");
          }
        }
    
    
        public Item Item => m_item;
    
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    
      }
    
      public class Item
      {
        public Item(string name, int value)
        {
          Name = name;
          Value = value;
        }
    
        public string Name { get; set; }
        public int Value { get; set; }
      }
