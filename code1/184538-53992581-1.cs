    public class GridEx : Grid, INotifyPropertyChanged
    {
        public delegate void ChildrenUpdatedEventHandler(DependencyObject visualAdded, DependencyObject visualRemoved);
        public event ChildrenUpdatedEventHandler ChildrenUpdated;
        public event PropertyChangedEventHandler PropertyChanged;
        public bool HasChildren => Children.Cast<UIElement>().Where(element => element != null).Count() > 0;
        public int ChildCount => Children.Cast<UIElement>().Where(element => element != null).Count();
        protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
        {
            base.OnVisualChildrenChanged(visualAdded, visualRemoved);
            ChildrenUpdated?.Invoke(visualAdded, visualRemoved);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HasChildren)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ChildCount)));
        }
    }
