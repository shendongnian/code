    public partial class MainWindow : Window, INotifyPropertyChanged
    {
      private List<string> aListOfItems;
      public event PropertyChangedEventHandler PropertyChanged;
      public List<string> AListOfItems
      {
         get { return aListOfItems; }
         set { aListOfItems = value; OnPropertyChanged("AListOfItems"); }
      }
      public MainWindow()
      {
         InitializeComponent();
         DataContext = this;
         AListOfItems = new List<string> { "item1", "item2", "item3", "zw1.txt","hey"};
         ThisIsTheRemoveCode();
      }
      protected void OnPropertyChanged(string name)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
      }
      private void ThisIsTheRemoveCode()
      {
         Regex regex = new Regex(@"^zw1\.txt$");
         for (int i = 0; i < AListOfItems.Count; i++)
            if (regex.Match(AListOfItems[i]).Success)
               AListOfItems.Remove(AListOfItems[i]);
      }
    }
