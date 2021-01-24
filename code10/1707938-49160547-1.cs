    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    
    namespace WpfApp1
    {
        internal class Model : INotifyPropertyChanged
        {
            private ObservableCollection<string> _collection;
    
            public Model()
            {
                UpdateText = new RelayCommand(UpdateTextExecute);
                Collection = new ObservableCollection<string>();
            }
    
            public RelayCommand UpdateText { get; }
    
            public ObservableCollection<string> Collection
            {
                get => _collection;
                set
                {
                    _collection = value;
                    OnPropertyChanged();
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void UpdateTextExecute(object s)
            {
                var text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                Collection.Add(text);
            }
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
