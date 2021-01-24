    bool found = false;
    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(this.Content as DependencyObject); i++)
    {
        var v = VisualTreeHelper.GetChild(this.Content as DependencyObject, i);
        if (v is Label && (v as Label).Content.ToString().Contains("abc"))
        {
            found = true;
            break;
        }
    }
    button.IsEnabled = !found;
