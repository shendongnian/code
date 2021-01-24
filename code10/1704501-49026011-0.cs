    public sealed class ItemViewModel : ViewModelBase
    {
        private bool isChecked;
        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                if (isChecked != value)
                {
                    isChecked = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
    }
