    private void Viewbox_Tapped(object sender, TappedRoutedEventArgs e)
    {
        Viewbox image = sender as Viewbox;
        Image imageControl = new Image() { Width = 500, Height = 500 };
        Uri uri = new Uri("Your image URL");
        BitmapImage source = new BitmapImage(uri);
        imageControl.Source = source;
        image.Child = imageControl;
        Panel parent = image.Parent as Panel;
        if (parent != null)
        {
            image.RenderTransform = new ScaleTransform() { ScaleX = 0.5, ScaleY = 0.5 };
            parent.Children.Remove(image);
            parent.HorizontalAlignment = HorizontalAlignment.Stretch;
            parent.VerticalAlignment = VerticalAlignment.Stretch;
            parent.Children.Add(new Popup() { Child = image, IsOpen = true, Tag=parent});
        }
        else
        {
            Popup popup = image.Parent as Popup;
            popup.Child = null;
            Panel panel = popup.Tag as Panel;
            image.RenderTransform = null;
            panel.Children.Add(image);
        }
    }
