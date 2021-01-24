    private PropertyChangedCallback OnTargetFileChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var ctrl = d as FileSelectGroup;
        if (ctrl != null)
        {
            System.IO.FileInfo f = ctrl.TargetFile;
            if (f != null)
            {
            }
        }
    }
