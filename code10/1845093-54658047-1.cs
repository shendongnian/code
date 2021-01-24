    var hd = new HoseData();
...
    PropertyInfo[] properties = typeof(HoseData).GetProperties();
    foreach (PropertyInfo pi in properties)
    {
        var name = pi.Name;
        var value = pi.GetValue(hd);
        var label = new Label()
        {
            Content = name
        };
        var textbox = new TextBox()
        {
            Text = value.ToString(),
        };
        var binding = new Binding(name)
        {
            Source = hd,
            Mode = BindingMode.TwoWay,
            UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
        };
        textbox.SetBinding(TextBox.TextProperty, binding);
        var stackpanel = new StackPanel()
        {
            Orientation = Orientation.Horizontal
        };
        stackpanel.Children.Add(label);
        stackpanel.Children.Add(textbox);
        sp.Children.Add(yourMainStackPanel);
    }
