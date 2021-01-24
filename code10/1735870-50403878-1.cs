    public class MainPageViewModel
    {
        public ObservableCollection<Ingredients> Items { get; set; }
        public MainPageViewModel()
        {
            Items = new ObservableCollection<Ingredients>()
            {
                new Ingredients()
                {
                    Ingredient_name= "Nico",
                    IsCheck=false
                },
                   new Ingredients()
                {
                    Ingredient_name= "mimi",
                    IsCheck=false
                },
                      new Ingredients()
                {
                    Ingredient_name= "kiki",
                    IsCheck=false
                },
                         new Ingredients()
                {
                    Ingredient_name= "zizi",
                    IsCheck=false
                },
                            new Ingredients()
                {
                    Ingredient_name= "sasa",
                    IsCheck=false
                },
    
            };
    
        }
    }
