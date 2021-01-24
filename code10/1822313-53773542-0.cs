                for (int i = 0; i < textToInt; i++)
                {
                    NewGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    NewGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    for (int j = 0; j < textToInt; j++)
                    {
                      
                        NewGrid.Children.Add(new Label { Text = "" +j},i,j);
                    }
                }
