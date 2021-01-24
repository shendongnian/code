    public partial class UCDataGrid : UserControl
    {
        public UCDataGrid()
        {
            InitializeComponent();
        }
        public static  DependencyProperty ControlWidthProperty =
        DependencyProperty.Register("ControlWidth", typeof(double), typeof(UCDataGrid),new UIPropertyMetadata());
        public int ControlWidth
        {
           get { return (int)GetValue(ControlWidthProperty); }
           set { SetValue(ControlWidthProperty, value);  }
        }
    }
