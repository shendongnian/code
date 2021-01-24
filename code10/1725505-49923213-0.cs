    private PropertyChangedCallback OnTargetFileChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var f = e.NewValue as System.IO.FileInfo;
        if (f != null)
        {
            //...
        }
    }
