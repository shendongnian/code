    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Window wnd = (Window)CreateWindow("WpfApplication1.Window2");
        wnd.Show();
    }
    public object CreateWindow(string fullClassName)
    {
        Assembly asm = this.GetType().Assembly;
        object wnd = asm.CreateInstance(fullClassName);
        if (wnd == null)
        {
            throw new TypeLoadException("Unable to create window: " + fullClassName);
        }
        return wnd;
    }
