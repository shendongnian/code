     private void addNewItem_Click(object sender, RoutedEventArgs e)
            {
                ColorDialog cd = new ColorDialog();
                if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var itemsCount = lstControl.Items.Count;
                    var colorName = cd.Color;
                    //Create rectangle object
                    System.Windows.Shapes.Rectangle myRect = new System.Windows.Shapes.Rectangle();
                    myRect.Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(colorName.A, colorName.R, colorName.G, colorName.B));
                    
                    myRect.Height = 10;
                    myRect.Width = 50;
    
                    TextBlock label = new TextBlock();
                    label.Height = 10;
                    label.Width = 50;
    
                    Grid layout = new Grid();
                    layout.Children.Add(myRect);
                    layout.Children.Add(label);
                    label.Text = colorName.Name;
                    var newItem = new ListBoxItem
                    {
                        Content = layout
                    };
    
                    lstControl.Items.Add(newItem);
                }
            }
