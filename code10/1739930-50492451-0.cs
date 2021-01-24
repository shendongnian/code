    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        var style = new Style();
        style.Setters.Add(new Setter(TextBox.ForegroundProperty, Brushes.Red));
        Application.Current.Resources.Add(typeof(TextBox), style);
    }
    void SomeOtherFunctionCalledLater()
    {
        Application.Current.Resources.Remove(typeof(TextBox));
        // create another style, maybe
    }
