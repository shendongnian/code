    public class PathViewModel 
    {
        public ObservableCollection<Point> Points { get; private set; }
        PathViewModel ()
        {
            Points = new ObservableCollection<Point> ();
        }
    }
