    public class Vertex : ViewModelBase
    {
        private Point point;
        public Point Point
        {
            get { return point; }
            set { point = value; OnPropertyChanged(); }
        }
    }
    public class ViewModel : ViewModelBase
    {
        public ViewModel()
        {
            Vertices.CollectionChanged += VerticesCollectionChanged;
        }
        public ObservableCollection<Vertex> Vertices { get; }
            = new ObservableCollection<Vertex>();
        private void VerticesCollectionChanged(
            object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged += VertexPropertyChanged;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems.OfType<INotifyPropertyChanged>())
                {
                    item.PropertyChanged -= VertexPropertyChanged;
                }
            }
            OnPropertyChanged(nameof(Vertices));
        }
        private void VertexPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Vertices));
        }
    }
