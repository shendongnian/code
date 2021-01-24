    public ObservableCollection<gameMatrix> gameMatrixlist;
    Binding binding;
    Ellipse ellipse;
    private void addEllipse()
    {
        gameMatrixlist = new ObservableCollection<gameMatrix>() { new gameMatrix() {IsShown = true } };
        binding = new Binding();
        binding.Source = gameMatrixlist[0];
        binding.Path = new PropertyPath("IsShown");
        binding.Converter = new VisibilityConverter();
            
        ellipse = new Ellipse();
        SolidColorBrush mySolidColorBrush = new SolidColorBrush();
        mySolidColorBrush.Color = Windows.UI.Color.FromArgb(255, 255, 106, 106);
        ellipse.Fill = mySolidColorBrush;
        ellipse.Height = 100;
        ellipse.Width = 100;
        ellipse.SetBinding(VisibilityProperty, binding);
        Grid.SetRow(ellipse, 0);
        Grid.SetColumn(ellipse, 0);
        gameFlat.Children.Add(ellipse);
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        addEllipse();
    }
    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        gameMatrixlist[0].IsShown = false;
    }
}
    public class gameMatrix : INotifyPropertyChanged
    {
        private bool _IsShown;
        public bool IsShown
        {
            get { return _IsShown; }
            set
            {
                if (value == _IsShown) return;
                _IsShown = value;
                OnPropertyChanged("IsShown");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
