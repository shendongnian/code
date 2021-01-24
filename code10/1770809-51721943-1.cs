    private static void OnCurrentReadingChanged(
        DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((Switch_box)d).OnChecking((bool)e.NewValue);
    }
    private void OnChecking(bool status)
    {
        if (status)
        {
            ((Storyboard)FindResource("OnChecking")).Begin(this);
        }
        else
        {
            ((Storyboard)FindResource("OnUnchecking")).Begin(this);
        }
    }
