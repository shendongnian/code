    public class GridEx : Grid, INotifyPropertyChanged
    {
        public delegate void ChildrenUpdatedEventHandler(DependencyObject visualAdded, DependencyObject visualRemoved);
        public event ChildrenUpdatedEventHandler ChildrenUpdated;
        public event PropertyChangedEventHandler PropertyChanged;
        public bool HasChildren => Children.Count > 0;
        public int ChildCount => Children.Count;
        protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
        {
            base.OnVisualChildrenChanged(visualAdded, visualRemoved);
            ChildrenUpdated?.Invoke(visualAdded, visualRemoved);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HasChildren)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ChildCount)));
        }
    }
