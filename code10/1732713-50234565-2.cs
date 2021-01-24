    public class CategoryAddValue
    {
        public Kategoria Category { get; set; }
        public List<string> ValueList { get; set; }
    
        private ICommand _addValue;
        public ICommand AddValue
        {
            get
            {
                return _addValue;
            }
        }
    
        public CategoryAddValue(RelayCommand command)
        {
            _addValue = command;
        }
    }
