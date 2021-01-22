    /// <summary>
    /// Interaction logic for TestCaret.xaml
    /// </summary>
    public partial class TestCaret : Window
    {
        public TestCaret()
        {
            InitializeComponent();
            Binding bnd = new Binding("CursorPosition");
            bnd.Mode = BindingMode.TwoWay;
            BindingOperations.SetBinding(this, CursorPositionProperty, bnd);
            this.DataContext = new TestCaretViewModel();
        }
        public int CursorPosition
        {
            get { return (int)GetValue(CursorPositionProperty); }
            set { SetValue(CursorPositionProperty, value); }
        }
        // Using a DependencyProperty as the backing store for CursorPosition.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CursorPositionProperty =
            DependencyProperty.Register(
                "CursorPosition",
                typeof(int),
                typeof(TestCaret),
                new UIPropertyMetadata(
                    0,
                    (o, e) =>
                    {
                        if (e.NewValue != e.OldValue)
                        {
                            TestCaret t = (TestCaret)o;
                            t.textBox1.CaretIndex = (int)e.NewValue;
                        }
                    }));
        private void textBox1_SelectionChanged(object sender, RoutedEventArgs e)
        {
            this.SetValue(CursorPositionProperty, textBox1.CaretIndex);
        }
    }
