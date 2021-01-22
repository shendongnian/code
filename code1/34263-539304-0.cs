    public void BuildGrid()
    {
        LayoutRoot.ShowGridLines = true;
        int rowIndex = 0;
        foreach (string s in _names)
        {
            LayoutRoot.RowDefinitions.Add(new RowDefinition());
            var btn = new Button()
            LayoutRoot.Children.Add(btn);
            Grid.SetRow(btn, rowIndex);
            rowIndex += 1;
        }
    }
    
