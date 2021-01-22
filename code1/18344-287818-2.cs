    public partial class TagControl : UserControl
    {
        public TagControl()
        {
            InitializeComponent();
        }
    
        public Tag TagData
        {
            get { return (Tag)GetValue(TagDataProperty); }
            set { SetValue(TagDataProperty, value); }
        }
    
        // Using a DependencyProperty as the backing store for TagData.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TagDataProperty =
            DependencyProperty.Register("TagData", typeof(Tag), typeof(TagControl), new PropertyMetadata(new PropertyChangedCallback(TagControl.OnTagDataPropertyChanged)));
    
        public static void OnTagDataPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var tc = obj as TagControl;
            if (tc != null) tc.UpdateTagData();
        }
    
        public void UpdateTagData()
        {
            text.Text = TagData.Title;
            scaleTx.ScaleX = scaleTx.ScaleY = TagData.Weight;
            this.InvalidateMeasure();
        }
    
    }
