     public class ViewModel:INotifyPropertyChanged
    {
        public ViewModel()
        {
            PropertyChanged += SelectedItemChanged;
        }
        private async void SelectedItemChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedItem))
            {
                await Foo();
            }
        }
        public Task Foo()
        {
            return Task.Run(() =>
            {
                var a = "B";
            });
        }
        private object _selectedItem;
        public object SelectedItem
        {
            get=> _selectedItem;
            set
            {
                if (value != _selectedItem)
                {
                    _selectedItem = value;
                    OnPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
