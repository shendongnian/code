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
                b.Click += Button_Click;
    
                //Calculate the place of the button
                int column = (int)(buttonCounter / 4);
                int row = buttonCounter % 4;
    
                //Check if you need to add a columns
                if(row == 0)
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
