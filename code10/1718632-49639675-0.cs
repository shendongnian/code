    class Choice
    {
        public string Symbol { get; set; }
        public string Description { get; set; }
    }
    class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Choice> ComboBoxChoices { get; set; }
        public Choice SelectedItem { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public MainViewModel()
        {
            ComboBoxChoices = new ObservableCollection<Choice>();
            ComboBoxChoices.Add(new Choice() { Symbol = "=", Description = "equals" });
            ComboBoxChoices.Add(new Choice() { Symbol = ">", Description = "greater than" });
            SelectedItem = ComboBoxChoices[0];
        }
    }
