    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            MatchingNames.ItemsSource = Enumerable
              .Range(0, int.Parse(N.Text))
              .Select(n1 => new
              {
                  Item = "Button " + n1
              });
        }
        public double ItemMaxHeight
        {
            get
            {
                if (MatchingNames == null)
                    return double.PositiveInfinity;
                double height = 0.0;
                var icg = MatchingNames.ItemContainerGenerator;
                for (int i = 0; i < MatchingNames.Items.Count; i++)
                    height += (icg.ContainerFromIndex(i) as FrameworkElement).ActualHeight;
                return height 
                    + tb.Margin.Top + tb.ActualHeight + tb.Margin.Bottom
                    + 6.0; // 6 should match the margin of the scrollviewer
            }
        }
        private void MatchingNames_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.HeightChanged)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ItemMaxHeight"));
        }
    }
