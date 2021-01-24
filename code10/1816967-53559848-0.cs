    public static void Bind(
        this DependencyObject obj, DependencyProperty property, object source, string path)
    {
        BindingOperations.SetBinding(obj, property, new Binding
        {
            Source = source,
            Path = new PropertyPath(path)
        });
    }
