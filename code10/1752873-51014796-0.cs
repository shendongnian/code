    public class A {
        private ObservableCollection<int> observableList;
        public ObservableCollection<int> ObservableList
        {
            get { return observableList; }
            set
            {
                observableList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ObservableList));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void Init() 
        {
            ObservableList = new ObservableCollection<int>();
        }
    }
