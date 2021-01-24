    public class ViewModel : INotifyPropertyChanged
    {
        private Model _model;
        
        public string Test
        {
            get
            {
                return _model.Test;
            }
            set
            {
                if(string.Equals(value, _model.Test, StringComparison.CurrentCulture))
                {
                    return;
                }
                _model.Test = value;
                OnPropertyChanged();
            }
        }
        
        public ViewModel(Model model)
        {
            _model = model;
        }
    }
