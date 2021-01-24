    // Codebehind 
    foreach (var imgPath in filePaths)
    {
        var li = new WrapPanel
        {
            Width = 150,
            Height = 200,
            Margin = new Thickness(5),
            VerticalAlignment = VerticalAlignment.Top,
            HorizontalAlignment = HorizontalAlignment.Left,
            Background = Brushes.DarkBlue
        };
        
        var img = new Image
        {
            Width = 150,
            Height = 150,
            VerticalAlignment = VerticalAlignment.Top,
            HorizontalAlignment = HorizontalAlignment.Stretch,
            Source = new BitmapImage(new Uri(imgPath, UriKind.RelativeOrAbsolute)) // this is the main difference with your version 
        };
        li.Children.Add(img);
        var textBlk = new TextBlock
        {
            Width = 150,
            Height = 50,
            VerticalAlignment = VerticalAlignment.Bottom,
            HorizontalAlignment = HorizontalAlignment.Stretch,
            Background = Brushes.Aqua,
            Text = "Test text"
        };
        li.Children.Add(textBlk);
        ListBox1.Items.Add(li);
    }
