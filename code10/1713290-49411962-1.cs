    Style _style;
    void Button_Click(object sender, RoutedEventArgs e)
    {
        if (_style == null)
        {
            _style = (Style)Application.Current.Resources[typeof(ToolTip)];
            Application.Current.Resources.Remove(typeof(ToolTip));
        }
        else
            Application.Current.Resources.Add(typeof(ToolTip), _style);
    }
