    public class CustomCanvas : Canvas, INotifyPropertyChanged
    {
        public ObservableCollection<string> Names { get; } = new ObservableCollection<string>();
        protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
        {
            Names.Clear();
            foreach(FrameworkElement child in Children)
            {
                Names.Add(child.Name);
            }
            OnPropertyChanged(new PropertyChangedEventArgs(""));
        }
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
