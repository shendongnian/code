    public class CounterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public string LastItemsText => Nummer.Last()?.Num.ToString();
        public ObservableCollection<NumberViewModel> Nummer { get; private set; } = new ObservableCollection<NumberViewModel>();
        public ICommand CountUpCommand { get; private set; }
        public CounterViewModel()
        {
            CountUpCommand = new Command(CountUp);
        }
        public void CountUp()
        {
            int newNumber = Nummer.Count + 1;
            Nummer.Add(new NumberViewModel { Num = newNumber});
            PropertyChanged(this, new PropertyChangedEventArgs(nameof(LastItemsText));
        }
    }
