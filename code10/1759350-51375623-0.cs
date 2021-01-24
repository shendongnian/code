    public sealed partial class MainPage : Page
    {
        public ObservableCollection<CurrentBooksList> currentBooksLists { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            currentBooksLists = new ObservableCollection<CurrentBooksList>();
            ObservableCollection<CurrentFoldersList> currentFoldersLists = new ObservableCollection<CurrentFoldersList>();
            currentFoldersLists.Add(new CurrentFoldersList() { BookCode = "abc123", CurrentBookArray1 = new ObservableCollection<CurrentBusList1>() { new CurrentBusList1() { Lockbook = "123abc" }, new CurrentBusList1() { Lockbook = "123def" } } });
            currentFoldersLists.Add(new CurrentFoldersList() { BookCode = "def456", CurrentBookArray1 = new ObservableCollection<CurrentBusList1>() { new CurrentBusList1() { Lockbook = "def456" } } });
            
            currentBooksLists.Add(new CurrentBooksList() { CurrentFoldersArray = currentFoldersLists });
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index;
            var subSelectedItem = ((FrameworkElement)sender).DataContext as CurrentBusList1;
            foreach (var item in currentBooksLists)
            {
                foreach (var folder in item.CurrentFoldersArray)
                {
                    foreach (var bus in folder.CurrentBookArray1)
                    {
                        if (bus == subSelectedItem)
                        {
                            index = currentBooksLists.IndexOf(item);
                            break;
                        }
                    }
                }
            }
        }
    }
    public class CurrentBooksList
    {
        public ObservableCollection<CurrentFoldersList> CurrentFoldersArray { get; set; }
    }
    public class CurrentFoldersList
    {
        public string BookCode { get; set; }
        public ObservableCollection<CurrentBusList1> CurrentBookArray1 { get; set; }
    }
    public class CurrentBusList1
    {
        public string Lockbook { get; set; }
    }
