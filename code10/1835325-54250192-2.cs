    public class ViewModel : INotifyPropertyChanged
    {
        #region Private Fields
        private ObservableCollection<string> mColorList;
        private ObservableCollection<string> mItemList;
        #endregion
        #region Public Properties
        /// <summary>
        /// This is list box 1 items source with colors
        /// </summary>
        public ObservableCollection<string> ColorList
        {
            get { return mColorList; }
            set
            {
                mColorList = value;
                NotifyPropertyChanged(nameof(ColorList));
            }
        }
        /// <summary>
        /// This is list box 2 items with results
        /// </summary>
        public ObservableCollection<string> ItemList
        {
            get { return mItemList; }
            set
            {
                mItemList = value;
                NotifyPropertyChanged(nameof(ItemList));
            }
        }
        #endregion
        #region Constructor
        public ViewModel()
        {
            // Initialization 
            ColorList = new ObservableCollection<string>() { "red", "blue", "yellow", "green" };
            ItemList = new ObservableCollection<string>() { "not selected!" };
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Called when selection is changed
        /// </summary>
        /// <param name="selectedItems"></param>
        public void OnSelectionChanged(IEnumerable<string> selectedItems)
        {
            ItemList.Clear();
            foreach (var item in selectedItems)
            {
                switch (item)
                {
                    case "red":
                        ItemList.Add("apple");
                        ItemList.Add("sun");
                        break;
                    case "blue":
                        ItemList.Add("sea");
                        ItemList.Add("sky");
                        break;
                }
            }
        }
        #endregion
        #region InterfaceImplementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
