    public int buttonCounter = 1;
    public Dictionary<Button, object> clientDict = new Dictionary<Button, object>();
    private void RemoveBtn(Button button)
    {
        var row = Grid.GetRow(button);
        var column = Grid.GetColumn(button);
        //Rearange
        foreach (var btn in clientDict.Keys)
        {
            var r = Grid.GetRow(btn);
            var c = Grid.GetColumn(btn);
            if (c > column || (c == column && r > row))
            {
                if (r != 0)
                {
                    //Set the row new
                    Grid.SetRow(btn, r - 1);
                }
                else
                {
                    //Need to set it to a new column
                    Grid.SetRow(btn, 3);
                    Grid.SetColumn(btn, c - 1);
                }
            }
        }
        myGrid.Children.Remove(button);
        clientDict.Remove(button);
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        //Create the button
        Button b = new Button();
        b.Height = 30;
        b.Width = 100;
        b.VerticalAlignment = VerticalAlignment.Top;
        b.HorizontalAlignment = HorizontalAlignment.Left;
        b.Margin = new Thickness(20, 20, 0, 0);
        b.Content = "Button " + buttonCounter;
        b.Click += HandleButtonClick;
        clientDict.Add(b, null);
        //Calculate the place of the button
        int column = (int)(clientDict.Count / 4);
        int row = clientDict.Count % 4;
        //Check if you need to add a columns
        if (row == 0 && myGrid.ColumnDefinitions.Count <= column)
        {
            ColumnDefinition col = new ColumnDefinition();
            col.Width = new GridLength(column, GridUnitType.Auto);
            myGrid.ColumnDefinitions.Add(col);
        }
        //Add the button
        myGrid.Children.Add(b);
        Grid.SetColumn(b, column);
        Grid.SetRow(b, row);
        buttonCounter++;
    }
    private void HandleButtonClick(object sender, RoutedEventArgs e)
    {
        //Execute whatever you want from you handler:
        var client = clientDict[sender as Button];
    }
