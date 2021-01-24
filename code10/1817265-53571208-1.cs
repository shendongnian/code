    class ViewModel : INotifyPropertyChanged
    {
        ...
        private string _text;
        public string Text
            {
                get => _text;
                set
                {
                    _text = value;
                    OnPropertyChanged();
                }
            }
        ...
    }
<!-- --->
    <TextBox Text="{Binding Text, UpdateSourceTrigger=PropertyChanged}" />
