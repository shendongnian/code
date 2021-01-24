    <UniformGrid Name="myGrid" Rows="2" Columns="3"/>
    for(int r = 0; r < myGrid.Rows; r++)
    {
        for(int c = 0; c < myGrid.Columns; c++)
        {
            var B = new Border { Margin = new Thickness(5), Background = Brushes.Green };
            myGrid.Children.Add(B);
        }
    }
