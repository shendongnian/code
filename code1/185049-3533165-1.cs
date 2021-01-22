    public class MenuItem
    {
        public string MenuItemText {get; set;}
        public ICommand MenuItemCommand {get; set;}
        public object MenuItemCommandParameter {get; set;}
    }
...
    public ObservableCollection<MenuItem> MenuItems;
