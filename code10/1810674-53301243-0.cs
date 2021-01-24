    private static void Refresh(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        MessageBox.Show("Refreshed!");
        View newView = e.NewValue as View;
        if (newView != null)
            newView.PropertyChanged += NewView_PropertyChanged;
        View oldView = e.OldValue as View;
        if (oldView != null)
            oldView.PropertyChanged -= NewView_PropertyChanged;
    }
    private static void NewView_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        View view = (View)sender;
        //view updated...
    }
