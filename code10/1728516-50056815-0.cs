    public class YourViewModel: INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection <MyDataRow> rows;
        public ObservableCollection<MyDataRow> Rows 
        {
            get {return rows;}
            set {
                Rows = value;
                NotifyPropertyChanged("Rows");
            }
        }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
       ....
    }
