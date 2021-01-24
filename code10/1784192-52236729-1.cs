    public class MenuPage : ContentPage
    {
        public ListView ListView { get { return listView; } }
        public MenuPage()
        {
            Icon = "hamburger.png";
            Title = "My great application";
            var masterPageItems = new List<MasterPageItem> ();
            masterPageItems.Add (new MasterPageItem {
            Title = "List Items",
            IconSource = "list_items.png",
            TargetType = typeof(ContactsPageCS)
            });
            masterPageItems.Add (new MasterPageItem {
            Title = "Deposit",
            IconSource = "deposit.png",
            TargetType = typeof(TodoListPageCS)
            });
            ..........
        }
    }
