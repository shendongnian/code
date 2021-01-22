    public class MainPageViewModel
    {
        public ObservableCollection<Country> Countries {get;set;}
    }
    public class Country
    {
        public string Name {get; set;}
        public bool IsChecked {get;set;}
        public IEnumerable<State> Children {get; set;}
        // Do not need parent for this.
    }
    
    public class State
    {
        public string Name {get; set;}
        public bool IsChecked {get; set;}
        public Country Parent {get; set;}
        public IEnumerable<City> Children {get; set;}
    }
    
    public class City
    {
        public string Name {get; set;}
        public bool IsChecked {get; set;} 
        public State Parent {get; set;}
    }
