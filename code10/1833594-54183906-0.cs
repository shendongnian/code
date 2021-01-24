    public class CreateGameViewModel
    {
        public Game Game { get; private set; }
        public List<SelectListItem> Categories { get; private set; }
        public List<SelectListItem> Publishers { get; private set; }
        public int[] SelectedCategory { get; set; }
    
        public CreateGameViewModel()
        {
           this.Game = new Game();
        }
        public CreateGameViewModel(List<Models.Category> categories, 
                                   List<Models.Publisher> publishers)
        {
            Categories = categories.Select(c => new SelectListItem() { Text = c.Name, 
         Value = c.Id.ToString() }).ToList();
            Publishers = publishers.Select(p => new SelectListItem() { Text = p.Name, 
         Value = p.Id.ToString() }).ToList();
        }
    }
