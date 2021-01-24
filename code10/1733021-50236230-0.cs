    public class ViewModel
    {
        public List<SelectListItem> ItemList { get; set; }
        public ViewModel()
        {
            ItemList = new List<SelectListItem>(); // note this
        }
    }
   
