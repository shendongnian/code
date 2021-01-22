    public class HomeViewModel
    {
        public HomeViewModel()
        {
            Items = new SelectList(new[] { "One", "Two" });
            CurrentItem = "Two";
        }
        public SelectList Items { get; set; }
        public string CurrentItem { get; set; }
    }
