    public class Ingredients : INotifyPropertyChanged
    {
        public Ingredients()
        {
    
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChang([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _Ingredient_name;
        public string Ingredient_name
        {
            get
            {
                return _Ingredient_name;
            }
            set
            {
                _Ingredient_name = value;
                OnPropertyChang();
            }
        }
    
        private bool _IsCheck;
        public bool IsCheck
        {
            get
            {
                return _IsCheck;
            }
            set
            {
                _IsCheck = value;
                OnPropertyChang();
            }
        }
    }
