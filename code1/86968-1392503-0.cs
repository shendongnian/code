    public class MenuItemViewModel
    {
        public MenuItemViewModel()
        {
            this.MenuItems = new List<MenuItemViewModel>();
        }
        public string Text { get; set; }
        public IList<MenuItemViewModel> MenuItems { get; private set; }
    }
