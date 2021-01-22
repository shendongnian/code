    class MainViewModel
    {
        public MainViewModel()
        {
            PointList = new ObservableCollection<Point>();
            // Some example data:
            AddPoint(new Point(10, 10));
            AddPoint(new Point(200, 200));
            AddPoint(new Point(500, 500));
        }
        public ObservableCollection<Point> PointList { get; private set; }
        public void AddPoint(Point p)
        {
            // 3 at most, please!
            if (PointList.Count == 3)
            {
                PointList.RemoveAt(0);
            }
            PointList.Add(p);
        }
    }
