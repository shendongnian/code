    public static class WindowExtensions
    {
        public static readonly DependencyProperty ReadScriptFilesCommandProperty = DependencyProperty.RegisterAttached(
            "ReadScriptFilesCommand",
            typeof(ICommand),
            typeof(WindowExtensions),
            new PropertyMetadata(default(ICommand), OnReadScriptFilesCommandChanged));
    
        private static void OnReadScriptFilesCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Window window = d as Window;
            if (window == null)
                return;
    
            if (e.NewValue is ICommand)
            {
                window.Drop += WindowOnDrop;
            }
            if (e.OldValue != null)
            {
                window.Drop -= WindowOnDrop;
            }
        }
    
        private static void WindowOnDrop(object sender, DragEventArgs e)
        {
            Window window = sender as Window;
            if (window == null)
                return;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                ICommand readScriptFilesCommand = GetReadScriptFilesCommand(window);
                readScriptFilesCommand.Execute(files);
            }
        }
    
        public static void SetReadScriptFilesCommand(DependencyObject element, ICommand value)
        {
            element.SetValue(ReadScriptFilesCommandProperty, value);
        }
    
        public static ICommand GetReadScriptFilesCommand(DependencyObject element)
        {
            return (ICommand)element.GetValue(ReadScriptFilesCommandProperty);
        }
    }
