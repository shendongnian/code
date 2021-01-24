    var labelControl = testStackPanel.Children
                                     .OfType<ContentControl>()
                                     .Where(x => x.Name.StartsWith("Label"));
    foreach (var item in labelControl)
    {
        item.Background = new SolidColorBrush(Colors.Red);
    }
