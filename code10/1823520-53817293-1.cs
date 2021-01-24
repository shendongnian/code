    for (int i = 0; i < 10; i++)
        for (int j = 0; j < 10; j++)
        {
            var myButton = new Button();
            grid.Children.Add(myButton);
            myButton.SetValue(Grid.ColumnProperty, i);
            myButton.SetValue(Grid.RowProperty, j);
            Binding myBinding = new Binding($"GridSize[{i},{j}]") { Source = this };
            myButton.SetBinding(Button.ContentProperty, myBinding);
        }
