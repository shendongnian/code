    public partial class MainWindow : Window
    {
        ObservableCollection<ListViewItemsData> _ListViewItemsCollections = new ObservableCollection<ListViewItemsData>();
        public ObservableCollection<ListViewItemsData> ListViewItemsCollections { get { return _ListViewItemsCollections; } }
    }
    public class ListViewItemsData
    {
        public string GridViewColumnName_ImageSource { get; set; }
        public string GridViewColumnName_LabelContent { get; set; }
        public string GridViewColumnName_ID { get; set; }
        public string GridViewColumnTags { get; set; }
        public string GridViewColumnLocation { get; set; }
    }
