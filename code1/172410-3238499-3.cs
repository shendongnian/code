    public class PathViewModel : INotifyPropertyChanged
    {
        private static readonly PropertyChangedEventArgs OmegaPropertyChanged = 
            new PropertyChangedEventArgs ("Omega");
        // returns true if there is at least one point in list, false
        // otherwise. useful for disambiguating against an empty list
        // (for which Omega returns 0,0) and real path coordinate
        public bool IsOmegaDefined { get { return Points.Count > 0; } }
        // gets last point in path, or 0,0 if no points defined
        public Point Omega 
        { 
            get 
            { 
                Point omega;
                if (IsOmegaDefined)
                {
                    omega = Points[Points.Count - 1];
                }
                return omega;
            } 
        }
        // gets points in path
        public ObservableCollection<Point> Points { get; private set; }
        PathViewModel ()
        {
            Points = new ObservableCollection<Point> ();
        }
        // interfaces
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        // private methods
        private void Points_CollectionChanged (
            object sender,
            NotifyCollectionChangedEventArgs e)
        {
            // if collection changed, chances are so did Omega!
            if (PropertyChanged != null)
            {
                PropertyChanged (this, OmegaPropertyChanged);
            }
        }
    }
