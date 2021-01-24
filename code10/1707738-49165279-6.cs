    private Grid ChangeContentObject()
    {
        Grid g = new Grid();
        g.Background = new SolidColorBrush(Colors.Red);
        g.HorizontalAlignment = HorizontalAlignment.Stretch;
        g.VerticalAlignment = VerticalAlignment.Stretch;
        // add grid line to show columns border
        g.ShowGridLines = true;
        
        ColumnDefinition columnDefinitionForPath = new ColumnDefinition();
        columnDefinitionForPath.Width = new GridLength(4, GridUnitType.Star);
        ColumnDefinition columnDefinitionForEmpty = new ColumnDefinition();
        columnDefinitionForEmpty.Width = new GridLength(6, GridUnitType.Star);
        g.ColumnDefinitions.Add(columnDefinitionForPath);
        g.ColumnDefinitions.Add(columnDefinitionForEmpty);
        var p1 = new Path();
        p1.Stroke = new SolidColorBrush(Colors.Brown);
        p1.StrokeThickness = 2;
        p1.Stretch = Stretch.Fill;
        p1.HorizontalAlignment = HorizontalAlignment.Stretch;
        var b1 = new Binding
        {
            // modified path data
            Source = "M 10,100 C 10,300 300,-200 300,100"
        };
        BindingOperations.SetBinding(p1, Path.DataProperty, b1);
        var p2 = new Path();
        p2.Stroke = new SolidColorBrush(Colors.Brown);
        p2.StrokeThickness = 2;
        p2.Stretch = Stretch.Fill;
        p2.HorizontalAlignment = HorizontalAlignment.Stretch;
        var b2 = new Binding
        {
            // modified path data
            Source = "M 100,10 C 100,30 -200,100 100,300"
        };
        BindingOperations.SetBinding(p2, Path.DataProperty, b2);
        g.Children.Add(p1);
        g.Children.Add(p2);
        Grid.SetColumn(p1, 0);
        Grid.SetColumn(p2, 1);
        return g;
    }
