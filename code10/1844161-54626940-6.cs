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
            ColorCollection.Add(new ColorData(new SolidColorBrush(System.Windows.Media.Color.FromArgb(colorName.A, colorName.R, colorName.G, colorName.B)), colorName.Name ));
        }
    }
