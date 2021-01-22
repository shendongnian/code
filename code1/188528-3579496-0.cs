    public static readonly DependencyProperty ThatDependencyPropertyProperty =
        DependencyProperty.Register("ThatDependencyProperty", typeof(ObservableCollection<SomeClass>)
            , typeof(MainWindow), new UIPropertyMetadata(null));
    public MainWindow() {
        this.ThatDependencyProperty = new ObservableCollection<SomeClass>();
    }
