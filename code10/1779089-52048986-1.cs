    foreach (var in gridBtn.Children.OfType<ToggleButton>)
    {
        int TagPlusOne = Convert.ToInt32(c.Tag) + 1;
        string PaddedResult = TagPlusOne.ToString().PadLeft(3, '0');
        foreach (var resourceOne in resourceList.Where(x => x == PaddedResult))
        {
            c.BorderBrush = Brushes.Red;
            c.BorderThickness = new Thickness(3, 3, 3, 3);
        }
    }
