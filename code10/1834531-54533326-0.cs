    public static readonly DependencyProperty XyFGDataProperty = DependencyProperty.RegisterAttached("XyFGData", typeof(ObservableCollection<XyDataSeries<double,double>>), typeof(MoveBlockModifier), new FrameworkPropertyMetadata(new ObservableCollection<XyDataSeries<double,double>>()));
    
        public ObservableCollection<XyDataSeries<double, double>> XyFGData
        {
            get { return (ObservableCollection < XyDataSeries<double, double>>)GetValue(XyFGDataProperty); }
            set { SetValue(XyFGDataProperty, value); }
        }
    ...
    
