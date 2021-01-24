       public class DynamicPolyline : Control, INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void OnPropertyChanged([CallerMemberName] string caller = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
            }
    
            public static readonly DependencyProperty PolylinePointsProperty =
                DependencyProperty.Register("PoilylinePoints", typeof(PointCollection), typeof(DynamicPolyline),
                    new PropertyMetadata(new PointCollection()));
    
            public PointCollection PolylinePoints
            {
                get { return (PointCollection)GetValue(PolylinePointsProperty); }
                set { SetValue(PolylinePointsProperty, value); }
            }
    
            private ObservableCollection<NotifyingPoint> _inputPoints;
            public ObservableCollection<NotifyingPoint> InputPoints
            {
                get { return _inputPoints; }
                set
                {
                    _inputPoints = value;
                    OnPropertyChanged();
                }
            }
    
            private void SetPolyline()
            {
                if (polyLine != null && InputPoints.Count >= 2)
                {
                    var newCollection = new PointCollection();
    
                    foreach (var point in InputPoints)
                    {
                      newCollection.Add(new Point(point.X, point.Y));
                    }
                
                    polyLine.Points = newCollection;
                }
            }
    
            private void InputPoints_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (var item in e.NewItems)
                    {
                        var point = item as NotifyingPoint;
                        point.PropertyChanged += InputPoints_PropertyChange;
                    }
                }
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (var item in e.OldItems)
                    {
                        var point = item as NotifyingPoint;
                        point.PropertyChanged -= InputPoints_PropertyChange;
                    }
                }
    
            }
    
            private void InputPoints_PropertyChange(object sender, PropertyChangedEventArgs e)
            {
                SetPolyline();
            }
    
    
            public DynamicPolyline()
            {
                InputPoints = new ObservableCollection<NotifyingPoint>();
                InputPoints.CollectionChanged += InputPoints_CollectionChanged;
                SetPolyline();
            }
    
            static DynamicPolyline()
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(DynamicPolyline), new FrameworkPropertyMetadata(typeof(DynamicPolyline)));
            }
    
            private Polyline polyLine;
    
            public override void OnApplyTemplate()
            {
                base.OnApplyTemplate();
                polyLine = this.Template.FindName("PART_Polyline", this) as Polyline;
    
            }
