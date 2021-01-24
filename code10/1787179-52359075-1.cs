    private void TextColourPicker_ColorChanged(ColorPicker sender, ColorChangedEventArgs args)
    {
        SolidColorBrush DefaultTextColour = new SolidColorBrush(TextColourPicker.Color);
        foreach (var item in ShellPage.MyNavView.MenuItems.OfType<NavigationViewItem>())
        {
            item.Foreground = DefaultTextColour;
        } 
    }
