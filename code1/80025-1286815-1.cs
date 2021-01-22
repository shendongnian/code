    public static readonly DependencyProperty StateProperty =
        DependencyProperty.Register("State", typeof(TabViewModelState), typeof(TabViewModel), new PropertyMetadata(OnStateChanged));
    private static void OnStateChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        TabViewModel viewModel= (TabViewModel)obj;
        //Do stuff with your viewModel
    }
