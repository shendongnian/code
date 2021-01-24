    private void Chip_Click(object sender, RoutedEventArgs e)
    {
        var myChip = new MaterialDesignThemes.Wpf.Chip()
        {
            Height = 50,
            Content = "My Chip Content",
            IsDeletable = true,
            ToolTip = "This is my Chip",
        };
        myChip.Click += ClickHandlerForMyChip;
        
        tabsRB.Children.Add(myChip);
    }
