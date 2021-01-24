            // Add the class name to the document
            TextBlock txt_selected_class = new TextBlock()
            {
                Text = $"{klasse} ({inp_tour_part.SelectedItem.ToString()})"
            };
            print_content.Children.Add(txt_selected_class);
            // Generate the headers
            DataGridTextColumn h_pos = new DataGridTextColumn()
            {
                Header = "Pos"
            };
            ...
            // Initiate the new grid
            Grid grid = new Grid();
            // make all the column defenitions
            ColumnDefinition pos = new ColumnDefinition();
            BindingOperations.SetBinding(pos, ColumnDefinition.WidthProperty, new Binding("ActualWidth") { Source = h_pos, Mode = BindingMode.OneWay });
            ...
            // Add the 3 upper headers (labels)
            Label partone = new Label()
            {
                Content = "Deel 1",
                Style = (Style)(Application.Current.Resources["DGHeaderStyle"])
            };
            partone.SetValue(Grid.ColumnSpanProperty, 5);
            partone.SetValue(Grid.ColumnProperty, 8);
            ...
            // Add the labels
            grid.Children.Add(partone);
            grid.Children.Add(parttwo);
            grid.Children.Add(total_result);
            // Add the grid to the layout
            print_content.Children.Add(grid);
            //Generate the DataGrid
            ...
