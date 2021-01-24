    public class Vm
    {
        public Vm()
        { 
           // new collection assigned via property because property setter adds event handler
           Values = new ObservableCollection<int>();
        }
    
        ObservableCollection<int> values;
        public ObservableCollection<int> Values
        {
            get => values;
            set
            {
                if (values != null) values.CollectionChanged -= CollectionChangedHandler;
                values = value;
                if (values != null) values.CollectionChanged += CollectionChangedHandler;
                OnPropertyChanged();
            }
        }
    
        private void CollectionChangedHandler(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("ValuesText");
        }
    
        public string ValuesText
        {
            get { return "Values: " + String.Join(", ", values);}
        }
    }
