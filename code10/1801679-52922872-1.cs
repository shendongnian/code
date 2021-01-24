        public class BindableValue<T> : INotifyPropertyChanged
        {
            private T _value;
            public T Value
            { get => _value; set => SetProperty(ref _value, value); }
            // INotifyPropertyChanged and SetProperty implementation goes here
        }
        private ObservableCollection<BindableValue<string>> _msg;
        public ObservableCollection<BindableValue<string>> Msg
        { get => _msg; set => SetProperty(ref _msg1, value); }
