    public partial class MainPage : ContentPage
    {
        public ObservableCollection<MyItemType> Items { get; set; } = new ObservableCollection<MyItemType>();
        int lastItemIndex;
        int currentItemIndex;
        public MainPage()
        {
            ...
            listView.ItemAppearing += ListView_ItemAppearing;
        }
        void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            MyItemType item = e.Item as MyItemType;
            currentItemIndex = Items.IndexOf(item);
            if (currentItemIndex > lastItemIndex)
            {
                stackLayout.IsVisible = false;
            }
            else
            {
                stackLayout.IsVisible = true;
            }
            lastItemIndex = currentItemIndex;
        }
    }
