            // Add the class name to the document
            TextBlock txt_selected_class = new TextBlock()
            {
                Text = "Recreate (Totaal)"
            };
            print_content.Children.Add(txt_selected_class);
            // Generate the headers
            DataGridTextColumn h_pos = new DataGridTextColumn()
            {
                Header = "Pos"
            };
            DataGridTextColumn h_nr = new DataGridTextColumn()
            {
                Header = "Nr"
            };
            DataGridTextColumn h_pilot = new DataGridTextColumn()
            {
                Header = "Naam piloot"
            };
            DataGridTextColumn h_pilot_club = new DataGridTextColumn()
            {
                Header = "Club"
            };
            DataGridTextColumn h_pilot_license = new DataGridTextColumn()
            {
                Header = "Licentie"
            };
            DataGridTextColumn h_navigator = new DataGridTextColumn()
            {
                Header = "Naam copiloot"
            };
            DataGridTextColumn h_navigator_club = new DataGridTextColumn()
            {
                Header = "Club"
            };
            DataGridTextColumn h_navigator_license = new DataGridTextColumn()
            {
                Header = "Licentie"
            };
            DataGridTextColumn h_part_1_points = new DataGridTextColumn()
            {
                Header = "Deel 1",
                HeaderStyle = (Style)(Application.Current.Resources["ColumnHeaderRotateStyle"])
            };
            DataGridTextColumn h_part_1_distance = new DataGridTextColumn()
            {
                Header = "Afstand",
                HeaderStyle = (Style)(Application.Current.Resources["ColumnHeaderRotateStyle"])
            };
            DataGridTextColumn h_part_2_tot_gtks = new DataGridTextColumn()
            {
                Header = "Totaal GTK's",
                HeaderStyle = (Style)(Application.Current.Resources["ColumnHeaderRotateStyle"])
            };
            DataGridTextColumn h_part_2_tot_time = new DataGridTextColumn()
            {
                Header = "Totaal tijdscontroles",
                HeaderStyle = (Style)(Application.Current.Resources["ColumnHeaderRotateStyle"])
            };
            DataGridTextColumn h_part_2_controls = new DataGridTextColumn()
            {
                Header = "Totaal controles",
                HeaderStyle = (Style)(Application.Current.Resources["ColumnHeaderRotateStyle"])
            };
            DataGridTextColumn h_part_2_distance = new DataGridTextColumn()
            {
                Header = "Totaal controles",
                HeaderStyle = (Style)(Application.Current.Resources["ColumnHeaderRotateStyle"])
            };
            DataGridTextColumn h_total_gtk = new DataGridTextColumn()
            {
                Header = "Totaal GTK",
                HeaderStyle = (Style)(Application.Current.Resources["ColumnHeaderRotateStyle"])
            };
            DataGridTextColumn h_total_distance = new DataGridTextColumn()
            {
                Header = "Totaal afstand",
                HeaderStyle = (Style)(Application.Current.Resources["ColumnHeaderRotateStyle"])
            };
            DataGridTextColumn h_total_total = new DataGridTextColumn()
            {
                Header = "Totaal controles",
                HeaderStyle = (Style)(Application.Current.Resources["ColumnHeaderRotateStyle"])
            };
            // Initiate the new grid
            Grid grid = new Grid();
            // make all the column defenitions
            ColumnDefinition pos = new ColumnDefinition();
            BindingOperations.SetBinding(pos, ColumnDefinition.WidthProperty, new Binding("ActualWidth") { Source = h_pos, Mode = BindingMode.OneWay });
            ColumnDefinition nr = new ColumnDefinition();
            BindingOperations.SetBinding(nr, ColumnDefinition.WidthProperty, new Binding("ActualWidth") { Source = h_nr, Mode = BindingMode.OneWay });
            ColumnDefinition pilot = new ColumnDefinition();
            BindingOperations.SetBinding(pilot, ColumnDefinition.WidthProperty, new Binding("ActualWidth") { Source = h_pilot, Mode = BindingMode.OneWay });
            ColumnDefinition pilot_club = new ColumnDefinition();
            BindingOperations.SetBinding(pilot_club, ColumnDefinition.WidthProperty, new Binding("ActualWidth") { Source = h_pilot_club, Mode = BindingMode.OneWay });
            ColumnDefinition pilot_license = new ColumnDefinition();
            BindingOperations.SetBinding(pilot_license, ColumnDefinition.WidthProperty, new Binding("ActualWidth") { Source = h_pilot_license, Mode = BindingMode.OneWay });
            ColumnDefinition navigator = new ColumnDefinition();
            BindingOperations.SetBinding(navigator, ColumnDefinition.WidthProperty, new Binding("ActualWidth") { Source = h_navigator, Mode = BindingMode.OneWay });
            ColumnDefinition navigator_club = new ColumnDefinition();
            BindingOperations.SetBinding(navigator_club, ColumnDefinition.WidthProperty, new Binding("ActualWidth") { Source = h_navigator_club, Mode = BindingMode.OneWay });
            ColumnDefinition navigator_license = new ColumnDefinition();
            BindingOperations.SetBinding(navigator_license, ColumnDefinition.WidthProperty, new Binding("ActualWidth") { Source = h_navigator_license, Mode = BindingMode.OneWay });
            ColumnDefinition part_1_points = new ColumnDefinition();
            BindingOperations.SetBinding(part_1_points, ColumnDefinition.WidthProperty, new Binding("ActualWidth") { Source = h_part_1_points, Mode = BindingMode.OneWay });
            ColumnDefinition part_1_distance = new ColumnDefinition();
            BindingOperations.SetBinding(part_1_distance, ColumnDefinition.WidthProperty, new Binding("ActualWidth") { Source = h_part_1_distance, Mode = BindingMode.OneWay });
            ColumnDefinition part_2_tot_gtks = new ColumnDefinition();
            BindingOperations.SetBinding(part_2_tot_gtks, ColumnDefinition.WidthProperty, new Binding("ActualWidth") { Source = h_part_2_tot_gtks, Mode = BindingMode.OneWay });
            ColumnDefinition part_2_tot_time = new ColumnDefinition();
            BindingOperations.SetBinding(part_2_tot_time, ColumnDefinition.WidthProperty, new Binding("ActualWidth") { Source = h_part_2_tot_time, Mode = BindingMode.OneWay });
            ColumnDefinition part_2_tot_controls = new ColumnDefinition();
            BindingOperations.SetBinding(part_2_tot_controls, ColumnDefinition.WidthProperty, new Binding("ActualWidth") { Source = h_part_2_controls, Mode = BindingMode.OneWay });
            ColumnDefinition part_2_distance = new ColumnDefinition();
            BindingOperations.SetBinding(part_2_distance, ColumnDefinition.WidthProperty, new Binding("ActualWidth") { Source = h_part_2_distance, Mode = BindingMode.OneWay });
            ColumnDefinition total_gtk = new ColumnDefinition();
            BindingOperations.SetBinding(total_gtk, ColumnDefinition.WidthProperty, new Binding("ActualWidth") { Source = h_total_gtk, Mode = BindingMode.OneWay });
            ColumnDefinition total_distance = new ColumnDefinition();
            BindingOperations.SetBinding(total_distance, ColumnDefinition.WidthProperty, new Binding("ActualWidth") { Source = h_total_distance, Mode = BindingMode.OneWay });
            ColumnDefinition total = new ColumnDefinition();
            BindingOperations.SetBinding(total, ColumnDefinition.WidthProperty, new Binding("ActualWidth") { Source = h_total_total, Mode = BindingMode.OneWay });
            // add all the column defenitions to the grid
            grid.ColumnDefinitions.Add(pos);
            grid.ColumnDefinitions.Add(nr);
            grid.ColumnDefinitions.Add(pilot);
            grid.ColumnDefinitions.Add(pilot_club);
            grid.ColumnDefinitions.Add(pilot_license);
            grid.ColumnDefinitions.Add(navigator);
            grid.ColumnDefinitions.Add(navigator_club);
            grid.ColumnDefinitions.Add(navigator_license);
            grid.ColumnDefinitions.Add(part_1_points);
            grid.ColumnDefinitions.Add(part_1_distance);
            grid.ColumnDefinitions.Add(part_2_tot_gtks);
            grid.ColumnDefinitions.Add(part_2_tot_time);
            grid.ColumnDefinitions.Add(part_2_tot_controls);
            grid.ColumnDefinitions.Add(part_2_distance);
            grid.ColumnDefinitions.Add(total_gtk);
            grid.ColumnDefinitions.Add(total_distance);
            grid.ColumnDefinitions.Add(total);
            // Add the 3 upper headers (labels)
            Label partone = new Label()
            {
                Content = "Deel 1",
                Style = (Style)(Application.Current.Resources["DGHeaderStyle"])
            };
            partone.SetValue(Grid.ColumnSpanProperty, 5);
            partone.SetValue(Grid.ColumnProperty, 8);
            Label parttwo = new Label()
            {
                Content = "Deel 2",
                Style = (Style)(Application.Current.Resources["DGHeaderStyle"])
            };
            parttwo.SetValue(Grid.ColumnSpanProperty, 5);
            parttwo.SetValue(Grid.ColumnProperty, 12);
            Label total_result = new Label()
            {
                Content = "Eind",
                Style = (Style)(Application.Current.Resources["DGHeaderStyle"])
            };
            total_result.SetValue(Grid.ColumnSpanProperty, 5);
            total_result.SetValue(Grid.ColumnProperty, 16);
            // Add the labels
            grid.Children.Add(partone);
            grid.Children.Add(parttwo);
            grid.Children.Add(total_result);
            // Add the grid to the layout
            print_content.Children.Add(grid);
            //Generate the DataGrid
            DataGrid list_results = new DataGrid()
            {
                IsReadOnly = true,
                ColumnHeaderStyle = (Style)(Application.Current.Resources["HeaderStyle"]),
                ColumnWidth = DataGridLength.Auto,
                RowBackground = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0)),    // Transparent color
                Foreground = new SolidColorBrush(Color.FromRgb(250, 250, 250)),
                AlternatingRowBackground = new SolidColorBrush(Color.FromRgb(85, 90, 98)),
                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0)),
                BorderThickness = new Thickness(0),
                AutoGenerateColumns = false,
                RowHeaderWidth = 0
            };
            // Set the result list to grid row 1
            list_results.SetValue(Grid.RowProperty, 1);
            // Add the headers
            list_results.Columns.Add(h_pos);
            list_results.Columns.Add(h_nr);
            list_results.Columns.Add(h_pilot);
            list_results.Columns.Add(h_pilot_club);
            list_results.Columns.Add(h_pilot_license);
            list_results.Columns.Add(h_navigator);
            list_results.Columns.Add(h_navigator_club);
            list_results.Columns.Add(h_navigator_license);
            list_results.Columns.Add(h_part_1_points);
            list_results.Columns.Add(h_part_1_distance);
            list_results.Columns.Add(h_part_2_tot_gtks);
            list_results.Columns.Add(h_part_2_tot_time);
            list_results.Columns.Add(h_part_2_controls);
            list_results.Columns.Add(h_part_2_distance);
            list_results.Columns.Add(h_total_gtk);
            list_results.Columns.Add(h_total_distance);
            list_results.Columns.Add(h_total_total);
            // Add the grid to the lay-out
            print_content.Children.Add(list_results);
