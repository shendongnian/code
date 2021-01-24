    public partial class TableTab : TabItem
    {
        public static readonly DependencyProperty TableIdProperty;
        public static readonly DependencyProperty TabItemHeaderProperty;
        public TableTab()
        {
            InitializeComponent();
            TabItemHeader = "head";
        }
        static TableTab()
        {
            TableIdProperty = DependencyProperty.Register("TableId", typeof(int), typeof(TableTab));
            TabItemHeaderProperty = DependencyProperty.Register("TabItemHeader", typeof(string), typeof(TableTab));
        }
        public int TableId
        {
            get { return (int)GetValue(TableIdProperty); }
            set { SetValue(TableIdProperty, value); }
        }
        public string TabItemHeader
        {
            get { return (string)GetValue(TabItemHeaderProperty); }
            set { SetValue(TabItemHeaderProperty, value); }
        }
    }
