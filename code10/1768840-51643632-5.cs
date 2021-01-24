    using System.ComponentModel;
    
    namespace CounterTest {
        public class CounterViewModel : ModelBase {
            private readonly Counter _myCounter = new Counter();
    
            public RelayCommand IncCommand { get; }
    
            public CounterViewModel() {
                IncCommand = new RelayCommand(_myCounter.Increment, () => true);
    
                _myCounter.PropertyChanged += OnModelPropertyChanged;
            }
    
            private void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e) {
                switch (e.PropertyName) {
                    case nameof(Counter.Cval):
                        RaisePropertyChanged(nameof(CounterString));
                        break;
                }
            }
    
            public string CounterString => $"Count is now {_myCounter.Cval}";
        }
    }
