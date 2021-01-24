    private void MainWindow_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        if (e.OldValue != null && e.OldValue is INotifyPropertyChanged)
        {
            ((INotifyPropertyChanged)e.OldValue).PropertyChanged -= MainWindow_PropertyChanged;
        }
        if (e.NewValue != null && e.NewValue is INotifyPropertyChanged)
        {
            ((INotifyPropertyChanged)e.NewValue).PropertyChanged += MainWindow_PropertyChanged;
        }
    }
    private void MainWindow_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
     ...
    }
