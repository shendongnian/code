    public partial class MyUserControl : UserControl
    {
        public event MyComboBoxSelectionChangedEventHandler MyComboBoxSelectionChanged;
        public MyUserControl()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource",
                typeof(System.Collections.IEnumerable),
                typeof(MyUserControl),
                new PropertyMetadata(null));
        public System.Collections.IEnumerable ItemsSource
        {
            get => GetValue(ItemsSourceProperty) as IEnumerable;
            set => SetValue(ItemsSourceProperty, (IEnumerable)value);
        }
        public static readonly DependencyProperty ItemTemplateProperty =
            DependencyProperty.Register("ItemTemplate",
                typeof(DataTemplate),
                typeof(MyUserControl),
                new PropertyMetadata(null));
        public DataTemplate ItemTemplate
        {
            get => GetValue(ItemTemplateProperty) as DataTemplate;
            set => SetValue(ItemTemplateProperty, (DataTemplate)value);
        }
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                MyComboBoxSelectionChanged?.Invoke(this,
                    new MyComboBoxSelectionChangedEventArgs() {MyComboBoxItem = e.AddedItems[0]});
            }
        }
    }
