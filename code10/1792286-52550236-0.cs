    <ListBox HorizontalAlignment="Left" Height="171" Margin="334,96,0,0" VerticalAlignment="Top" Width="248" AllowDrop="True"  x:Name="SerialNumbersListBox"
                     ItemsSource="{Binding SerialNumbers}">
                <ListBox.ItemTemplate>
                    <DataTemplate>
                        <CheckBox Content="{Binding name}"
                                  IsChecked="{Binding IsSelected}"/>
                    </DataTemplate>
                </ListBox.ItemTemplate>
            </ListBox>
    public class SerialNumbersListBoxViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public class StatusOption
        {
            public string name { get; set; }
            public bool IsSelected { get; set; }
        }
        private ObservableCollection<StatusOption> _SerialNumbers;
        public ObservableCollection<StatusOption> SerialNumbers
        {
            get
            {
                return _SerialNumbers;
            }
            set
            {
                if (value != _SerialNumbers)
                {
                    _SerialNumbers = value;
                    OnPropertyChanged(nameof(SerialNumbers));
                }
            }
        }
        public void GetSerialNumbers()
        {
            if (_SerialNumbers == null)
                _SerialNumbers = new ObservableCollection<StatusOption>();
            for (int i = 0; i < 10; i++)
            {
                StatusOption x = new StatusOption();
                x.name = "Random name" + i;
                x.IsSelected = false;
                _SerialNumbers.Add(x);
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public SerialNumbersListBoxViewModel()
        {
            GetSerialNumbers();
            }
    }
