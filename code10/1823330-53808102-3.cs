    foreach (Grid b in main_grid.Children)
    {
        foreach (Control s in b.Children)
        {
            if (s.SomeEnumValue == SomeEnum.Value)
            {
                s.Background = Brushes.Orange;
            }
            else
            {
                s.Background = defaultBackground;
            }
        }
    }
