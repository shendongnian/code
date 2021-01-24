    public partial class MainWindow : Window, INotifyPropertyChanged {
        public MainWindow() {
            InitializeComponent();
            DataContext = this;
            SizeChanged += SizeWasChanged;
        }
        private void SizeWasChanged(object sender, SizeChangedEventArgs e) {
            OnPropertyChanged(nameof(Row2MaxHeight));
            OnPropertyChanged(nameof(Row2MaxHeightInner));
        }
        public double Row2MaxHeight => ActualHeight - MyGrid.RowDefinitions[0].ActualHeight - MyGrid.RowDefinitions[2].ActualHeight - 50; //50 or something is around the Size of the title bar of the window
        public double Row2MaxHeightInner => Row2MaxHeight - MyInnerGrid.RowDefinitions[0].ActualHeight - 6; //6 should match the margin of the scrollviewer
        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e) {
            MatchingNames.ItemsSource = Enumerable
                .Range(0, int.Parse(N.Text))
                .Select(n1 => new {
                    Item = "Button " + n1
                });
            OnPropertyChanged(nameof(Row2MaxHeight));
            OnPropertyChanged(nameof(Row2MaxHeightInner));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
