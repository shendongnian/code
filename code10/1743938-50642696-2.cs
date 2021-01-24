    public partial class UCDataGrid : UserControl
    {
        public UCDataGrid()
        {
            InitializeComponent();
        }
        public static  DependencyProperty ControlWidthProperty =
        DependencyProperty.Register("ControlWidth", typeof(double), typeof(UCDataGrid),new UIPropertyMetadata());
        public double ControlWidth
        {
           get { return (double)GetValue(ControlWidthProperty); }
           set { SetValue(ControlWidthProperty, value);  }
        }
    }
