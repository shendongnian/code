    public class ViewModel : BaseViewModel
    {
        private bool _isTextBoxEnabled;
        public bool IsTextBoxEnabled
        {
            get { return _isTextBoxEnabled; }
            set
            {
                if (value != _isTextBoxEnabled)
                    _isTextBoxEnabled = value;
                this.RaisePropertyChanged("IsTextBoxEnabled");
            }
        }
    }
