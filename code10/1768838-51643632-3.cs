    using System.ComponentModel;
    namespace CounterTest {
        public class ModelBase : INotifyPropertyChanged {
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(PropertyChangedEventArgs e) => PropertyChanged?.Invoke(this, e);
            protected void RaisePropertyChanged(string propertyName) => OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    }
