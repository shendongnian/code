    RowDefinition row = this.mainGrid.RowDefinitions[0];
    if (row.Height.GridUnitType == GridUnitType.Auto)
    {
        if (this.mainGrid.ActualHeight > this.ActualHeight)
        {
            row.Height = new GridLength(1, GridUnitType.Star);
        }
    }
    else
    {
        if (this.dataGrid.DesiredSize.Height < row.ActualHeight)
        {
            row.Height = GridLength.Auto;
        }
    }
